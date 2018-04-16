using System.Collections.Generic;
using System.Linq;
using SelfieFriend.Domain.Core;
using SelfieFriend.Domain.Interfaces;
using System.Data.Entity;

namespace SelfieFriend.Infrastructure.Data
{
    public class InquiryRepository:IInquiryRepository
    {
        private readonly SelfieFriendContext _db;

        public InquiryRepository(SelfieFriendContext db)
        {
            _db = db;
        }

        public List<Inquiry> GetList()
        {
           return _db.Inquiries.ToList();
        }

        public Inquiry Get(int id)
        {
            return _db.Inquiries.Find(id);
        }

        public Inquiry GetByOfferingId(int vkId, int offeringId)
        {
            return _db.Inquiries
                .Include(i => i.User)
                .FirstOrDefault(i => i.User.VkId == vkId && i.OfferingId == offeringId);
        }

        public List<Inquiry> GetListByVkId(int id)
        {
            return _db.Inquiries.Include(i => i.User).Where(i => i.User.VkId == id).ToList();
        }

        public void Create(Inquiry item)
        {
            //////
            var inquiry = _db.Inquiries.FirstOrDefault(i => i.UserId == item.UserId && i.OfferingId == item.OfferingId);
            if(inquiry!=null)return;

            _db.Inquiries.Add(item);
            _db.SaveChanges();

        }

        public void Update(Inquiry item)
        {
           _db.Entry(item).State=EntityState.Modified;
        }

        public bool IsInquiredOffering(int vkId, int offeringId)
        {
            var inquiry = _db.Inquiries
                .Include(i => i.User)
                .FirstOrDefault(i => i.User.VkId == vkId && i.OfferingId == offeringId);

            return inquiry != null;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var inquiry = _db.Inquiries
                .Include(i=>i.Purchase)
                .Include(i=>i.Purchase.PurchasePhoto)
                .FirstOrDefault(i=>i.Id==id);

            if (inquiry == null) return;

            if (inquiry.Purchase != null) { 
            var photo = _db.PurchasePhotos.Find(inquiry.Purchase.PurchasePhoto?.Id);
            if (photo != null)
                _db.PurchasePhotos.Remove(photo);
            }

            var purchase = _db.Purchases.Find(inquiry.Purchase?.Id);
            if (purchase != null)
                _db.Purchases.Remove(purchase);


            //На скорую руку
            var removeMessage = _db.Messages.Where(m => m.InquiryId == inquiry.Id);
            _db.Messages.RemoveRange(removeMessage);

            _db.Inquiries.Remove(inquiry);
            _db.SaveChanges();
        }

        public List<Inquiry> GetListForUser(User user)
        {
            var inquiries = _db.Inquiries
                .Include(i => i.Offering)
                .Include(i => i.User)
                .Include(i => i.Purchase)
                .Include(i => i.Offering.User)
                .Include(i => i.Offering.OfferingPhoto)
                .Where(i => i.Offering.UserId == user.Id && i.Offering.Closed!=true)
                .ToList();
            return inquiries;

        }

        public List<Inquiry> GetUserList(User user)
        {
            var inquiries = _db.Inquiries
                .Include(a => a.User)
                .Include(o => o.Offering)
                .Include(o => o.Offering.OfferingPhoto)
                .Include(o => o.Offering.User)
                .Include(p => p.Purchase)
                .Where(a => a.User.Id == user.Id)
                .ToList();

            return inquiries;
        }
    }
}
