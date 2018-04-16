using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SelfieFriend.Models;
using SelfieFriend.Services.Interface;

namespace SelfieFriend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PurchasesController : ApiAuthorizationController
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IFileService _fileService;


        public PurchasesController(IPurchaseService purchaseService, IFileService fileService)
        {
            _purchaseService = purchaseService;
            _fileService = fileService;
        }

        [HttpGet]
        [Route("api/GetPhoto")]
        public object GetPhoto(int applicationId)
        {
            string hostWithPort = Request.RequestUri.Host + ":" + Request.RequestUri.Port;
            var obj = new
            {
                ImagePath = @"http://" + hostWithPort + @"/" + _purchaseService.GetPhoto(applicationId)
            };
            return obj;
        }


        [HttpPost]
        [Route("api/sendPurchase")]
        public HttpResponseMessage SendPurchase([FromBody] PurchaseModel purchaseModel)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }


            var filename = _fileService.ImageDecodeAndSave(purchaseModel.Photo);

            _purchaseService.Create("Content/photos/" + filename, purchaseModel.ApplicationId, UserId);


            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPost]
        [Route("api/PayPurchase")]
        public HttpResponseMessage Pay(int applicationId)
        {
            _purchaseService.Pay(applicationId, UserId);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }


        [HttpGet]
        [Route("api/SellerPurchase")]
        public IEnumerable<object> PurchaseForSeller()
        {
            return _purchaseService.GetSellerPurchasesByVkId(UserId);
        }

        [HttpGet]
        [Route("api/CustomerPurchase")]
        public IEnumerable<object> PurchaseForCustomer()
        {
            return _purchaseService.GetCustomerPurchasesByVkId(UserId);
        }


    }
}
