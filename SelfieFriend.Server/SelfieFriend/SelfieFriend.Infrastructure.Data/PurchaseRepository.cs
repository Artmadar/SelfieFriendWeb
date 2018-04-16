using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SelfieFriend.Domain.Core;
using SelfieFriend.Domain.Interfaces;

namespace SelfieFriend.Infrastructure.Data
{
    public class PurchaseRepository:IPurchaseRepository
    {
        private SelfieFriendContext _db;

        public PurchaseRepository(SelfieFriendContext db)
        {
            _db = db;
        }

        public List<Purchase> GetUserList()
        {
            return _db.Purchases.ToList();
        }

        public Purchase GetPurchase(int id)
        {
            return _db.Purchases.Find(id);
        }

        //Needing tests
        public List<Purchase> GetCustomerPurchasesByVkId(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.VkId == id);
            var purchase = _db.Purchases.Include(a => a.Inquiry).Where(p => p.Inquiry.UserId == user.Id).ToList();
            return purchase;
        }

        //Needing tests
        public List<Purchase> GetSellerPurchasesByVkId(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.VkId == id);
            var purchase = _db.Purchases.Include(a => a.Inquiry).Include(a => a.Inquiry.Offering)
                .Where(p => p.Inquiry.Offering.UserId == user.Id).ToList();
            return purchase;
        }

        public void Create(Purchase item)
        {
            _db.Purchases.Add(item);
            _db.SaveChanges();
        }

        public void Create(string photoPath, int inquiryId, int vkId)
        {
            var inq = _db.Inquiries.Include(o => o.Offering).Include(u => u.Offering.User)
                .FirstOrDefault(a => a.Id == inquiryId);


            if (inq == null || inq.Offering.User.VkId != vkId)
                return;


            var photo = new PurchasePhoto() {ImagePath = photoPath};
            _db.PurchasePhotos.Add(photo);


            var inquiry = _db.Inquiries.Find(inquiryId);
            if (inquiry != null)
            {
                Purchase purchase = new Purchase()
                {
                    Inquiry = inquiry,
                    PurchasePhoto = photo,
                    Bought = false
                };
                _db.Purchases.Add(purchase);
                _db.SaveChanges();
            }
        }

        public bool Bought(int id)
        {
            var purchase = _db.Purchases.Include(p => p.PurchasePhoto).FirstOrDefault(a => a.Id == id);
            if (purchase != null && purchase.PurchasePhoto != null)
            {
                purchase.Bought = true;
                _db.SaveChanges();
                return true;
            }

            return false;
        }

        public void Update(Purchase item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var purchase = _db.Purchases.Find(id);
            if (purchase != null)
            {
                _db.Purchases.Remove(purchase);
                _db.SaveChanges();
            }
        }

        public void Pay(int applicationId, int vkId)
        {
            var purchase
                = _db.Purchases.Include(a => a.Inquiry).Include(u => u.Inquiry.User)
                    .Where(a => a.Inquiry.Id == applicationId).ToList().FirstOrDefault();
            if (purchase != null && purchase.Inquiry.User.VkId == vkId)
            {
                purchase.Bought = true;
            }
            _db.Entry(purchase).State = EntityState.Modified;
            _db.SaveChanges();
        }

        //Сделать проверку!
        public string GetPhoto(int inquiryId)
        {
            var purchase = _db.Purchases.Include(p => p.PurchasePhoto).Include(a => a.Inquiry)
                .FirstOrDefault(a => a.Inquiry.Id == inquiryId);
            if (purchase != null && purchase.Bought)
            {
                return purchase.PurchasePhoto.ImagePath;
            }

            return null;
        }

    }
}
