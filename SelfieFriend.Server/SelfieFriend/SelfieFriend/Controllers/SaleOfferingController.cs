using SelfieFriend.Domain.Core;
using SelfieFriend.Models;
using SelfieFriend.Services.Interface;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SelfieFriend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SaleOfferingController : ApiAuthorizationController
    {
        private readonly IOfferingService _offeringService;
        private readonly IFileService _fileService;

        public SaleOfferingController(IOfferingService offeringService, IFileService fileService)
        {
            _offeringService = offeringService;
            _fileService = fileService;
        }


        public IEnumerable<object> Get()
        {
            string hostPort = Request.RequestUri.Host + ":" + Request.RequestUri.Port;

            return _offeringService.Get(hostPort, UserId, OfferingType.Sale);
        }

        /// <summary>
        /// Получение предложений других пользователей
        /// </summary>
        /// <param name="startPosition">Номер предложения с которого нужн</param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetSaleOfferings")]
        public IEnumerable<object> Get(int startPosition, int count)
        {
            var hostPort = Request.RequestUri.Host + ":" + Request.RequestUri.Port;

            return _offeringService.Get(hostPort, UserId, startPosition, count, OfferingType.Sale);
        }


        [HttpGet]
        [Route("api/MySaleOfferings")]
        public IEnumerable<object> GetMyOfferings()
        {
            string hostWithPort = Request.RequestUri.Host + ":" + Request.RequestUri.Port;

            return _offeringService.GetUserOfferings(hostWithPort, UserId, OfferingType.Sale);
        }





        [HttpPost]
        [Route("api/SaleOfferChange")]
        public HttpResponseMessage ChangeOffering([FromBody]PhotoModel model)
        {

            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (string.IsNullOrEmpty(model.Photo))
            {
                _offeringService.OfferChange(model.Id, UserId, model.Cost, model.Description, model.Title);
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            var fileName = _fileService.ImageDecodeAndSave(model.Photo);
            _offeringService.OfferChange(model.Id, "Content/photos/" + fileName, UserId, model.Cost, model.Description, model.Title);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("api/SaleUploadFileApi")]
        public object UploadFile([FromBody]PhotoModel model)
        {

            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var fileName = _fileService.ImageDecodeAndSave(model.Photo);


            _offeringService.Create("Content/photos/" + fileName, UserId, model.Cost, model.Description, model.Title,OfferingType.Sale);

            var offer = _offeringService.GetOfferingByFilePath("Content/photos/" + fileName,
                 Request.RequestUri.Host + ":" + Request.RequestUri.Port);


            var offerings = new List<object>();
            offerings.Add(offer);

            return offerings;
        }


        [HttpDelete]
        [Route("api/CloseSaleOffering")]
        public HttpResponseMessage Close(int offeringId)
        {
            _offeringService.CloseOffering(UserId, offeringId);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }


    }
}
