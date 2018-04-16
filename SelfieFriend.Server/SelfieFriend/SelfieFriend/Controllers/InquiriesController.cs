using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using SelfieFriend.Models;
using SelfieFriend.Services.Interface;

namespace SelfieFriend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InquiriesController : ApiAuthorizationController
    {
        private readonly IInquiryService _inquiryService;
        

        public InquiriesController(IInquiryService inquiryService)
        {
            _inquiryService = inquiryService;
        }

        /// <summary>
        /// Заявка на предложение
        /// </summary>
        /// <param name="model">JsonFile{Text:"text", OfferingId:id} </param>
        /// <returns>HttpResponseMessage</returns>
        /// // POST: api/Applications
        [HttpPost]
        [Route("api/Applications")]
        public async Task<HttpResponseMessage> Post([FromBody] InquiriyModel model)
        {
            var obj = _inquiryService.Create(model.OfferingId,UserId,model.Text);
            if(obj==null)
                return await Task.FromResult(
                    Request.CreateResponse(HttpStatusCode.BadRequest));

            return await Task.FromResult(
                Request.CreateResponse(HttpStatusCode.OK));

        }

        /// <summary>
        /// Действие для получения заявок на предложения
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetApplicationForUser")]
        public IEnumerable<object> GetInquiriesForUser()
        {
            string hostWithPort = Request.RequestUri.Host + ":" + Request.RequestUri.Port;
            return _inquiryService.GetInquiriesListForUser(hostWithPort, UserId);
        }


        /// <summary>
        /// Действие для получения заявок пользователя на предложение другого пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetUserApplications")]
        public IEnumerable<object> GetUserInquiries()
        {
            string hostWithPort = Request.RequestUri.Host + ":" + Request.RequestUri.Port;
            return _inquiryService.GetUserInquiries(hostWithPort, UserId);
        }

        /// <summary>
        /// Действие для удаления заявки пользователя на предлодение
        /// </summary>
        /// <param name="offeringId">id предложения</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/DeleteApplication")]
        public HttpResponseMessage Delete(int offeringId)
        {
            _inquiryService.DeleteInquiryByOfferingId(UserId, offeringId);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
