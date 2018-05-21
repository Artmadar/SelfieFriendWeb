using SelfieFriend.Domain.Core;
using SelfieFriend.Infrastructure.Data;
using SelfieFriend.Services.Interface.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;


namespace SelfieFriend.Infrastructure.Business
{
    public class UserBuyOfferingService
    {
        private readonly UserBuyOfferingReporsitory _userBuyOfferingReporsitory;
        private readonly UserService _userService;
        private readonly SubscribeService _subscribeService;

        public UserBuyOfferingService(UserBuyOfferingReporsitory userBuyOfferingReporsitory, UserService userService, SubscribeService subscribeService)
        {
            _userBuyOfferingReporsitory = userBuyOfferingReporsitory;
            _userService = userService;
            _subscribeService = subscribeService;
        }

        public bool BuyOffering(int vkId, int offeringId)
        {
            var user = _userService.GetUserByVkId(vkId);
            var userId = user.Id;

            var isExistPurchase = _userBuyOfferingReporsitory.GetByUserIdAndOfferingId(userId, offeringId) != null;

            if (isExistPurchase)
            {
                return false;
            }

            var canBuy = _subscribeService.ChangeSubscribeInfoWhenMakePurchase(vkId);

            if (canBuy)
            {
                var userBuyOffering = new UserBuyOffering(userId, offeringId);
                _userBuyOfferingReporsitory.Create(userBuyOffering);
                return true;
            }
            return false;
        }

        public List<OfferingPostModel> GetUserBuyOfferingHistory(int vkId,string hostPort)
        {
            var user = _userService.GetUserByVkId(vkId);
            var userId = user.Id;
            var userBuyOfferings =_userBuyOfferingReporsitory.GetListByUserId(userId).Select(x=>x.Offering).ToList();

            return CreateOfferingPostModels(userBuyOfferings,hostPort,true);
        }

        private List<OfferingPostModel> CreateOfferingPostModels(List<Offering> offerings,string hostPort, bool isOriginal=false)
        {
            var offeringModels = new List<OfferingPostModel>();

            foreach (var offering in offerings)
            {
                string path = offering.User.AvatarPath;
                if (string.IsNullOrEmpty(path))
                {
                    path = Path.Combine("http://", hostPort + @"/" + "Content/Avatars/size50/camera_50.png");
                }



                var offeringPostModel = new OfferingPostModel();
                offeringPostModel.OfferingId = offering.Id;
                offeringPostModel.FirstName = offering.User.FirstName;
                offeringPostModel.LastName = offering.User.LastName;


                offeringPostModel.ImagePath = isOriginal ? Path.Combine("http://", hostPort + @"/" + offering.OfferingPhoto.ImagePath) : Path.Combine("http://", hostPort + @"/" + offering.OfferingPhoto.ImageWithWaterMarkPath);
                offeringPostModel.Title = offering.Title;
                offeringPostModel.Price = offering.Price.ToString(CultureInfo.InvariantCulture);
                offeringPostModel.DateCreated = offering.DateCreated;
                offeringPostModel.AvatarPath = path;
                offeringPostModel.Description = offering.Desctiption;
                offeringPostModel.CategotyName = offering.OfferingCategory != null ? offering.OfferingCategory.Name : "NoCategory";

                offeringModels.Add(offeringPostModel);
            }
            return offeringModels;
        }


    }
}
