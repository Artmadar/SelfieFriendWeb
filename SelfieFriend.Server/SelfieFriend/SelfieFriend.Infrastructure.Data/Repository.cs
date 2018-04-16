using System;
using System.Collections.Generic;
using SelfieFriend.Domain.Core;
using SelfieFriend.Domain.Interfaces;

namespace SelfieFriend.Infrastructure.Data
{
    //
    public class Repository : IRepository<BaseSelfieFriendEntity>
    {
        public BaseSelfieFriendEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BaseSelfieFriendEntity> GetList()
        {
            throw new NotImplementedException();
        }

        public void Create(object obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
