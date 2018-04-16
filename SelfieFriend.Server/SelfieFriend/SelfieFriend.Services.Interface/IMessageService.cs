using System.Collections.Generic;
using SelfieFriend.Services.Interface.Models;

namespace SelfieFriend.Services.Interface
{
    public interface IMessageService
    {
        void SendMessage(int vkId, int inquiryId, string text);
        List<MessagePostModel> GetMessages(int vkId, int inquiryId);
        List<MessagePostModel> GetLastMessageList(int vkId);


    }
}
