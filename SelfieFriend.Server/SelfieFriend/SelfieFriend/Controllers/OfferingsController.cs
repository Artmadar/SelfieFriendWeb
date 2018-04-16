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
    public class OfferingsController : ApiAuthorizationController
    {

        private readonly IOfferingService _offeringService;
        private readonly IFileService _fileService;

        public OfferingsController(IOfferingService offeringService,IFileService fileService)
        {
            _offeringService = offeringService;
            _fileService = fileService;
        }


        public IEnumerable<object> Get()
        {
            string hostPort = Request.RequestUri.Host + ":" + Request.RequestUri.Port;

            return _offeringService.Get(hostPort, UserId);
        }

        /// <summary>
        /// Получение предложений других пользователей
        /// </summary>
        /// <param name="startPosition">Номер предложения с которого нужн</param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetOfferings")]
        public IEnumerable<object> Get(int startPosition,int count)
        {
            var hostPort = Request.RequestUri.Host + ":" + Request.RequestUri.Port;

            return _offeringService.Get(hostPort, UserId, startPosition, count);
        }


        [HttpGet]
        [Route("api/MyOfferings")]
        public IEnumerable<object> GetMyOfferings()
        {
            string hostWithPort = Request.RequestUri.Host + ":" + Request.RequestUri.Port;

            return _offeringService.GetUserOfferings(hostWithPort, UserId);
        }


       


        [HttpPost]
        [Route("api/OfferChange")]
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
        [Route("api/UploadFileApi")]
        public object UploadFile([FromBody]PhotoModel model)
        {

            if (model == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var fileName = _fileService.ImageDecodeAndSave(model.Photo);


            _offeringService.Create("Content/photos/" + fileName, UserId, model.Cost, model.Description, model.Title);

           var offer = _offeringService.GetOfferingByFilePath("Content/photos/" + fileName,
                Request.RequestUri.Host + ":" + Request.RequestUri.Port);


            var offerings = new List<object>();
            offerings.Add(offer);

            return offerings;
        }


        [HttpDelete]
        [Route("api/CloseOffering")]
        public HttpResponseMessage Close(int offeringId)
        {
            _offeringService.CloseOffering(UserId,offeringId);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }


    }
}
