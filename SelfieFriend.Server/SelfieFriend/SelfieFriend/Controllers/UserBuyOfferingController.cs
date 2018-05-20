using SelfieFriend.Infrastructure.Business;
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

    }
}
