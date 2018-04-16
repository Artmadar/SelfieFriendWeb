using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SelfieFriend.Domain.Core;
using SelfieFriend.Domain.Interfaces;

namespace SelfieFriend.Infrastructure.Data
{
    public class UserRepository:IUserRepository
    {
        private readonly SelfieFriendContext _db;

        public UserRepository(SelfieFriendContext db)
        {
            _db = db;
        }


        public List<User> GetList()
        {
            return _db.Users.ToList();
        }

        public User Get(int id)
        {
            return _db.Users.Find(id);
            
        }

        public User GetByVkId(int id)
        {
            return _db.Users.FirstOrDefault(u => u.VkId == id);
        }

        public void Create(User item)
        {
            _db.Users.Add(item);
            _db.SaveChanges();
        }

        public void Update(User item)
        {
           _db.Entry(item).State=EntityState.Modified;
           _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _db.Users.Find(id);
            if (user == null) return;
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
    }
}
