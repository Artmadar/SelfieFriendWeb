using System.Collections.Generic;
using SelfieFriend.Domain.Core;

namespace SelfieFriend.Domain.Interfaces
{
    /// <summary>
    /// Базовый интерфейс репозиториев, содержащий CRUD-операции
    /// </summary>
    /// <typeparam name="T">BaseSelfieFriendEntity</typeparam>
    public interface IRepository<T> where T : BaseSelfieFriendEntity
    {
        T Get(int id);
        IEnumerable<T> GetList();
        void Create(T obj);
        void Delete(int id);
        void Update(T obj);
    }
}
