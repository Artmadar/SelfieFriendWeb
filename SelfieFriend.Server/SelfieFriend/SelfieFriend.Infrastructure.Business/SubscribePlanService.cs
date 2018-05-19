using SelfieFriend.Domain.Core;
using SelfieFriend.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SelfieFriend.Infrastructure.Business
{
    public class SubscribeService
    {
        private readonly SubscribePlanRepository _subscribePlanRepository;
        private readonly PurchasedSubscribeRepository _purchasedSubscribeRepository;
        private readonly UserService _userService; 

        public SubscribeService(SubscribePlanRepository subscribePlanRepository, PurchasedSubscribeRepository purchasedSubscribeRepository,UserService userService)
        {
            _subscribePlanRepository = subscribePlanRepository;
            _purchasedSubscribeRepository = purchasedSubscribeRepository;
            _userService = userService;
        }


        public List<SubscribePlan> GetPlanList()
        {
            return _subscribePlanRepository.GetList().ToList();
        }

        public void CreatePlan(SubscribePlan subscribePlan)
        {
            _subscribePlanRepository.Create(subscribePlan);
        }


        public PurchasedSubscribe GetUserPlan(int vkId)
        {
            var user = _userService.GetUserByVkId(vkId);
            return _purchasedSubscribeRepository.GetByUserId(user.Id);
        }

        public void UpdateSubscribe(int vkId, int planId)
        {
            var userPurchasedSubscribe = GetUserPlan(vkId);
            var newPlan = _subscribePlanRepository.Get(planId);
            var user = _userService.GetUserByVkId(vkId);

            if (userPurchasedSubscribe == null)
            {
                userPurchasedSubscribe = new PurchasedSubscribe
                {
                    UserId = user.Id,
                    PhotoToBuyCount = 0,
                    StartDate=DateTime.UtcNow,
                    EndDate = DateTime.UtcNow
                };
                _purchasedSubscribeRepository.Create(userPurchasedSubscribe);
            }

            var month = newPlan.MonthCount;

            if (userPurchasedSubscribe.EndDate == null || userPurchasedSubscribe.EndDate < DateTime.UtcNow)
            {
               
                userPurchasedSubscribe.StartDate = DateTime.UtcNow;
                userPurchasedSubscribe.EndDate = DateTime.UtcNow.AddMonths(month);
                userPurchasedSubscribe.PhotoToBuyCount = newPlan.PhotoToBuyCount;
               
            }
            else
            {
                if (userPurchasedSubscribe.PhotoToBuyCount == 0)
                    userPurchasedSubscribe.StartDate = DateTime.UtcNow;
                userPurchasedSubscribe.EndDate = DateTime.UtcNow.AddMonths(month);
                userPurchasedSubscribe.PhotoToBuyCount += newPlan.PhotoToBuyCount;
            }

            _purchasedSubscribeRepository.Update(userPurchasedSubscribe);
        }


        /// <summary>
        /// Check Subscribe
        /// </summary>
        /// <param name="vkId"></param>
        /// <returns></returns>
        public bool CheckSubscribe(int vkId)
        {
            var userPurchasedSubscribe = GetUserPlan(vkId);
            if (userPurchasedSubscribe == null)
                return false;

            if (userPurchasedSubscribe.EndDate < DateTime.UtcNow)
                return false;

            return true;
        }


    }
}
