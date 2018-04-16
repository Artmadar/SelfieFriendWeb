using System.Collections.Generic;
using System.Globalization;
using System.IO;
using SelfieFriend.Domain.Core;
using SelfieFriend.Domain.Interfaces;
using SelfieFriend.Services.Interface;
using SelfieFriend.Services.Interface.Models;

namespace SelfieFriend.Infrastructure.Business
{
     public class InquiryService: IInquiryService
    {

        private readonly IInquiryRepository _inquiryRepository;

        private readonly IUserService _userService;

        private readonly IMessageService _messageService;

        public InquiryService(IInquiryRepository inquiryRepository,IUserService userService,IMessageService messageService)
        {
            _inquiryRepository = inquiryRepository;
            _userService = userService;
            _messageService = messageService;
        }

        public bool IsExistInquiryOnOffering(int vkId, int offeringId)
        {
           return _inquiryRepository.IsInquiredOffering(vkId,offeringId);
        }

        public void DeleteInquiryByOfferingId(int vkId, int offeringId)
        {
            if (!IsExistInquiryOnOffering(vkId, offeringId))
                return;

            var inq = _inquiryRepository.GetByOfferingId(vkId, offeringId);
            if(inq==null)
                return;

            _inquiryRepository.Delete(inq.Id);

        }

        public object Create(int offeringId, int vkId, string text)
        {
            var user = _userService.GetUserByVkId(vkId);

            if (user == null) return null;

            var inquiry = new Inquiry()
            {
                OfferingId = offeringId,
                Text = text,
                UserId = user.Id
            };

            _inquiryRepository.Create(inquiry);
            
            _messageService.SendMessage(vkId, _inquiryRepository.GetByOfferingId(vkId, offeringId).Id, text);

            return inquiry;
        }

        public IEnumerable<object> GetInquiriesListForUser(string hostPort, int vkId)
        {
            var user = _userService.GetUserByVkId(vkId);
            if (user == null) return null;

            var inquiries = _inquiryRepository.GetListForUser(user);
            var inquiriesForUser =new List<InqueriesForUserModel>();

            foreach (var inquiry in inquiries)
            {


                bool uploaded = inquiry.Purchase != null;

                inquiriesForUser.Add(new InqueriesForUserModel()
                {
                    ApplicationId = inquiry.Id,
                    ApplicationUserFirstName = inquiry.User?.FirstName,
                    ApplicationUserLastName = inquiry.User?.LastName,
                    Price = inquiry.Offering.Price.ToString(CultureInfo.InvariantCulture),
                    OfferingPhoto = Path.Combine("http://", hostPort + @"/" + inquiry.Offering?.OfferingPhoto?.ImagePath),
                    Uploaded = uploaded,
                    Text = inquiry.Text,
                    AvatarPath = inquiry.User?.AvatarPath,
                    Title = inquiry.Offering?.Title

                });

            }
            inquiriesForUser.Reverse();

            return inquiriesForUser;



        }

        public IEnumerable<object> GetUserInquiries(string hostPort, int vkId)
        {
            var user = _userService.GetUserByVkId(vkId);
            if (user == null) return null;

            var inquiries = _inquiryRepository.GetUserList(user);

            var userInquiries = new List<UserInquiries>();


            foreach (var inquiry in inquiries)
            {
                var readyToBay = false;
                var readyToDownload = false;

                if (inquiry.Purchase != null)
                {
                    readyToBay = true;
                    if (inquiry.Purchase.Bought)
                    {
                        readyToDownload = true;
                    }
                }

                userInquiries.Add(new UserInquiries()
                {
                    ApplicationId = inquiry.Id,
                    OfferingUserFirstName = inquiry.Offering.User.FirstName,
                    OfferingUserLastName = inquiry.Offering.User.LastName,
                    ReadyToBay = readyToBay,
                    ReadyToDownload = readyToDownload,
                    OfferingPhoto = Path.Combine("http://", hostPort + @"/" + inquiry.Offering.OfferingPhoto.ImagePath),
                    Price = inquiry.Offering.Price.ToString(CultureInfo.InvariantCulture),
                    Text = inquiry.Text,
                    AvatarPath = inquiry.Offering.User.AvatarPath,
                    Title = inquiry.Offering.Title

                });

            }

            userInquiries.Reverse();
            return userInquiries;

        }
    }
}
