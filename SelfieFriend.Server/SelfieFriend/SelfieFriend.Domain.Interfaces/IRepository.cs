using System.Collections.Generic;
using SelfieFriend.Domain.Core;

namespace SelfieFriend.Domain.Interfaces
{
    /// <summary>
    /// Базовый интерфейс репозиториев, содержащий CRUD-операции
    /// </summary>
    /// <typeparam name="T">BaseSelfieFriendEntity</typeparam>
    public interface IRepository<out T> where T : BaseSelfieFriendEntity
    {
        T Get(int id);
        IEnumerable<T> GetList();
        void Create(object obj);
        void Delete(int id);
        void Update(object obj);
    }
}
