using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfieFriend.Domain.Core;
using SelfieFriend.Domain.Interfaces;

namespace SelfieFriend.Infrastructure.Data
{
    public class MessageRepository:IMessageRepository
    {
        private readonly IUserRepository _userRepository;

        private readonly SelfieFriendContext _db;

        public MessageRepository(IUserRepository userRepository,SelfieFriendContext db)
        {
            _userRepository = userRepository;
            _db = db;
        }

        public void Create(int userId, int inquiryId, string text)
        {
            var message = new Message()
            {
                UserId = userId,
                InquiryId = inquiryId,
                Text = text,
                DateCreated = DateTime.UtcNow
            };

            _db.Messages.Add(message);
            _db.SaveChanges();

        }

        public List<Message> GetList(int inquiryId)
        {
            return _db.Messages
                .Include(m => m.User)
                .Include(m=>m.Inquiry)
                .Include(m=>m.Inquiry.Offering)
                .Where(m => m.InquiryId == inquiryId).ToList();
        }

        public List<Message> GetLastMessageList(int userId)
        {
            return _db.Messages
                .Include(m => m.Inquiry)
                .Include(m=>m.Inquiry.User)
                .Include(m => m.Inquiry.Offering)
                .Include(m=>m.Inquiry.Offering.User)
                .Where(
                    m => (m.Inquiry.UserId == userId &&
                          m.DateCreated == _db.Messages.Where(d => d.InquiryId == m.InquiryId)
                              .Select(d => d.DateCreated).Max()) ||
                         (m.Inquiry.Offering.UserId == userId && m.DateCreated == _db.Messages
                              .Where(d => d.InquiryId == m.InquiryId).Select(d => d.DateCreated).Max())
                ).ToList();

        }

        public void Delete(int id)
        {
            var message = _db.Messages.Find(id);

            if (message != null)
            {
                _db.Messages.Remove(message);
                _db.SaveChanges();
            }
        }
    }
}
