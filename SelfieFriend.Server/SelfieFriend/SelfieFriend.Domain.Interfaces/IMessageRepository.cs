using System.Collections.Generic;
using SelfieFriend.Domain.Core;

namespace SelfieFriend.Domain.Interfaces
{
    public interface IMessageRepository
    {
        void Create(int userId, int inquiryId, string text);
        List<Message> GetList(int inquiryId);
        List<Message> GetLastMessageList(int userId);
        void Delete(int id);
    }
}
