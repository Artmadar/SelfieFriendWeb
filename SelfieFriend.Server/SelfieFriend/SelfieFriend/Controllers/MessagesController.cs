using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using SelfieFriend.Models;
using SelfieFriend.Services.Interface;

namespace SelfieFriend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MessagesController : ApiAuthorizationController
    {

        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        [Route("api/SendMessage")]
        public void SendMessage([FromBody] MessageModel model)
        {
            _messageService.SendMessage(UserId,model.ApplicationId,model.Text);
        }

        [HttpGet]
        [Route("api/GetMessangerList")]
        public IEnumerable<object> GetMessangerList()
        {

            return _messageService.GetLastMessageList(UserId);
        }

        [HttpGet]
        [Route("api/GetMessages")]
        public IEnumerable<object> GetMessages(int applicationId)
        {
            return _messageService.GetMessages(UserId, applicationId);
        }



    }
}
