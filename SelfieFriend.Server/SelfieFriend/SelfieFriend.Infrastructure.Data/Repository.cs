using System.Collections.Generic;
using SelfieFriend.Domain.Core;
using SelfieFriend.Domain.Interfaces;

namespace SelfieFriend.Infrastructure.Data
{
   
    public class Repository<TBaseSelfieFriendEntity> : IRepository<TBaseSelfieFriendEntity>  where TBaseSelfieFriendEntity: BaseSelfieFriendEntity
    {
        protected readonly SelfieFriendContext _db;

        public Repository(SelfieFriendContext db)
        {
            _db = db;
        }

        public TBaseSelfieFriendEntity Get(int id)
        {
            return _db.Set<TBaseSelfieFriendEntity>().Find(id);
        }

        public IEnumerable<TBaseSelfieFriendEntity> GetList()
        {
            return _db.Set<TBaseSelfieFriendEntity>();
        }

        public void Create(TBaseSelfieFriendEntity obj)
        {
            _db.Set<TBaseSelfieFriendEntity>().Add(obj);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = _db.Set<TBaseSelfieFriendEntity>().Find(id);
            _db.Set<TBaseSelfieFriendEntity>().Remove(obj);
            _db.SaveChanges();
        }

        public void Update(TBaseSelfieFriendEntity obj)
        {
            _db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
