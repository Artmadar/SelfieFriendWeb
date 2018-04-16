using System.Collections.Generic;
using SelfieFriend.Domain.Interfaces;
using SelfieFriend.Services.Interface;
using SelfieFriend.Services.Interface.Models;

namespace SelfieFriend.Infrastructure.Business
{
    public class MessageService:IMessageService
    {
        private readonly IUserService _userService;
        private readonly IMessageRepository _messageRepository;

        public MessageService(IUserService userService,IMessageRepository messageRepository)
        {
            _userService = userService;
            _messageRepository = messageRepository;
        }

        public void SendMessage(int vkId, int inquiryId, string text)
        {
            var userId = _userService.GetUserByVkId(vkId).Id;
            _messageRepository.Create(userId,inquiryId,text);

        }

        public List<MessagePostModel> GetMessages(int vkId, int inquiryId)
        {

            var userId = _userService.GetUserByVkId(vkId).Id;
            var messages = _messageRepository.GetList(inquiryId);

            var messagesListPostModel = new List<MessagePostModel>();

            bool myMessage;

            foreach (var message in messages)
            {

                if (message.UserId == userId)
                {
                    myMessage = true;
                }
                else
                {
                    myMessage = false;
                }

                messagesListPostModel.Add(new MessagePostModel()
                {
                    AvatarPath   = message.User.AvatarPath,
                    Text = message.Text,
                    FirstName = message.User.FirstName,
                    LastName = message.User.LastName,
                    ApplicationId = message.InquiryId,
                    Title = message.Inquiry.Offering.Title,
                    MyMessage = myMessage
                });
            }



            return messagesListPostModel;
        }

        public List<MessagePostModel> GetLastMessageList(int vkId)
        {
            var userId = _userService.GetUserByVkId(vkId).Id;
            var messages = _messageRepository.GetLastMessageList(userId);

            var messagesListPostModel = new List<MessagePostModel>();

            foreach (var message in messages)
            {

                string avatarPath;
                string firstName;
                string lastName;

                if (message.Inquiry.UserId == userId)
                {
                    avatarPath = message.Inquiry.Offering.User.AvatarPath;
                    firstName = message.Inquiry.Offering.User.FirstName;
                    lastName = message.Inquiry.Offering.User.LastName;

                }
                else
                {
                    avatarPath = message.Inquiry.User.AvatarPath;
                    firstName = message.Inquiry.User.FirstName;
                    lastName = message.Inquiry.User.LastName;
                }


                messagesListPostModel.Add(
                    new MessagePostModel()
                    {
                        ApplicationId = message.InquiryId,
                        Text = message.Text,
                        AvatarPath = avatarPath,
                        LastName = lastName,
                        FirstName = firstName,
                        Title = message.Inquiry.Offering.Title
                        
                    }
                    );                
            }


            return messagesListPostModel;


        }
    }
}
