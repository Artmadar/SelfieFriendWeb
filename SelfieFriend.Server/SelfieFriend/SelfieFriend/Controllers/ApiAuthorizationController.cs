using SelfieFriend.Infrastructure.Business;
using SelfieFriend.Services.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using System.Web.WebPages;
using SelfieFriend.Services.Interface.Models;

namespace SelfieFriend.Controllers
{
    /// <summary>
    /// Класс проверки авторизации пользователя
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiAuthorizationController : ApiController
    {
        /// <summary>
        /// Свойство идентификации пользователя, представляет собой Id пользователя в Vk.com
        /// </summary>
        public int UserId { get; private set; }

        private readonly IAuthrorizeService _authrorizeServise;

        protected ApiAuthorizationController()
        {
            //HACK: Этот класс наследуют другие контроллеры... не могу обьявить в Ninject... 
            _authrorizeServise = new AuthrorizeService();
        }

        
        public override async Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            //Получаем access_token из хедера
            IEnumerable<string> headerValues;
            controllerContext.Request.Headers.TryGetValues("access_token", out headerValues);

            //Если хедер пустой, то пользователь считаетсмя неавторизованным
            var headersOfValuesList = headerValues as IList<string> ?? headerValues.ToList();
            if (headersOfValuesList.First().IsEmpty())
            {
                
                return await Task.FromResult(
                    controllerContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Хедр пустой пришел с vk"));
            }

           //Проверяем через сервис валидность токена доступа, сервис возвращает данные о пользователе
            var userInfo = await _authrorizeServise.Authorize(headersOfValuesList.First());


            //Если данных нет, то пользователь считается неавторизованным 
            if (userInfo == null)
            {
                return await Task.FromResult(
                    controllerContext.Request.CreateResponse(HttpStatusCode.Unauthorized));
            }

            //Установка свойства идентификации пользователя
            UserId = ((UserPostModel)userInfo).response.First().uid;

            return await base.ExecuteAsync(controllerContext, cancellationToken);

        }




    }
}
