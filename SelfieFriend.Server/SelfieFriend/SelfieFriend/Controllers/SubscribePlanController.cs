using SelfieFriend.Domain.Core;
using SelfieFriend.Infrastructure.Business;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SelfieFriend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SubscribePlanController : ApiAuthorizationController
    {
        private readonly SubscribeService _subscribePlanService;

        public SubscribePlanController(SubscribeService subscribePlanService)
        {
            _subscribePlanService = subscribePlanService;
        }


        [HttpGet]
        [Route("GetSubscribePlans")]
        public List<SubscribePlan> GetPlans()
        {
            var plans = _subscribePlanService.GetPlanList();
            return plans;
        }


        [HttpGet]
        [Route("GetSubscribe")]
        public PurchasedSubscribe GetSubscribe()
        {
            var plan = _subscribePlanService.GetUserPlan(UserId);
            return plan;
        }

        [HttpPost]
        [Route("Subscribe")]
        public HttpResponseMessage Subscribe(int id)
        {
            _subscribePlanService.UpdateSubscribe(UserId, id);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }


    }
}
