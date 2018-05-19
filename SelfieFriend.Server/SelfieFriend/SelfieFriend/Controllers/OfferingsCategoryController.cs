using SelfieFriend.Domain.Core;
using SelfieFriend.Infrastructure.Business;
using System.Collections.Generic;
using System.Web.Http;

namespace SelfieFriend.Controllers
{
    public class OfferingsCategoryController : ApiAuthorizationController
    {
        private readonly OfferingsCategoryService _offeringsCategoryService;
        public OfferingsCategoryController(OfferingsCategoryService offeringsCategoryService)
        {
            _offeringsCategoryService = offeringsCategoryService;
        }

        [HttpGet]
        [Route("OfferingsCategory")]
        public List<OfferingCategory> GetList()
        {
            return _offeringsCategoryService.GetList();
        }

        public void CreateNew(string name, string description = null)
        {
            _offeringsCategoryService.Create(name, description);
        }

    }
}
