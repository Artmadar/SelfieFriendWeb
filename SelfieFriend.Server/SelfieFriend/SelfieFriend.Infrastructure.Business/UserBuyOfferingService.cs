using SelfieFriend.Domain.Core;
using SelfieFriend.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public List<UserBuyOffering> GetUserBuyOfferingHistory(int vkId)
        {
            var user = _userService.GetUserByVkId(vkId);
            var userId = user.Id;
            var userBuyOfferings =_userBuyOfferingReporsitory.GetListByUserId(userId);

            return userBuyOfferings;
        }


    }
}
