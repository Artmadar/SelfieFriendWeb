using SelfieFriend.Infrastructure.Business;
using SelfieFriend.Services.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SelfieFriend.Controllers
{
    public class UserBuyOfferingController : ApiAuthorizationController
    {
        private readonly UserBuyOfferingService _userBuyOfferingService;

        public UserBuyOfferingController(UserBuyOfferingService userBuyOfferingService)
        {
            _userBuyOfferingService = userBuyOfferingService;
        }


        [HttpGet]
        [Route("offering/purchases/history")]
        public List<OfferingPostModel> GetHistory()
        {
            string hostPort = Request.RequestUri.Host + ":" + Request.RequestUri.Port;
            var result = _userBuyOfferingService.GetUserBuyOfferingHistory(UserId, hostPort);
            return result;
        }



        [HttpPost]
        [Route("offering/buy")]
        public HttpResponseMessage Buy(int offeringId)
        {

            var isComplite = _userBuyOfferingService.BuyOffering(UserId, offeringId);

            if (isComplite)
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
        }


    }
}
