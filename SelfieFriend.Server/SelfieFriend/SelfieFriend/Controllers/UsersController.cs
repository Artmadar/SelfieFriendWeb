using System.Web.Http;
using System.Web.Http.Cors;
using SelfieFriend.Services.Interface;


namespace SelfieFriend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiAuthorizationController
    {
        private readonly IUserService _userServise;

        public UsersController(IUserService userServise)
        {
            _userServise = userServise;
        }

        [HttpGet]
        public object Get()
        {
            return _userServise.GetUserByVkId(UserId);   
        }


    }
}
