
using System.Collections.Generic;
using SelfieFriend.Domain.Core;

namespace SelfieFriend.Domain.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetList();
        User Get(int id);
        User GetByVkId(int id);
        void Create(User item);
        void Update(User item);
        void Delete(int id);
    }
}
