using SelfieFriend.Services.Interface;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SelfieFriend.Controllers
{
    /// <summary>
    /// Контроллер для авторизации пользователя
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthorizeController : ApiController
    {
        private readonly IAuthrorizeService _authrorizeServise;

        public AuthorizeController(IAuthrorizeService authrorizeServise)
        {
            _authrorizeServise = authrorizeServise;
        }


        [HttpPost]
        [Route("api/authorize/{access_token}")]
        public async Task<object> Login(string access_token)
        {
            var response = await _authrorizeServise.Authorize(access_token);
            if (response == null)
                return ResponseMessage(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            else
                return response;
        }


       

    }
}
