using SelfieFriend.Services.Interface;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SelfieFriend.Domain.Core;
using SelfieFriend.Domain.Interfaces;
using SelfieFriend.Infrastructure.Data;
using SelfieFriend.Services.Interface.Models;

namespace SelfieFriend.Infrastructure.Business
{
    public class AuthrorizeService : IAuthrorizeService
    {
        private readonly IUserRepository _userRepository;

        public AuthrorizeService()
        {
            //HACK: проблемма с Ninject API-Controller (ApiAuthorizationController)
            _userRepository = new UserRepository(new SelfieFriendContext());
        }

        public async Task<object> Authorize(string accessToken)
        {
            var client = new HttpClient();

            //var response =
            //    await client.GetAsync(
            //            $"https://api.vk.com/method/users.get?access_token={accessToken}&version=5.74&fields=photo_100&name_case=Nom");

            var response =
                await client.GetAsync(
                        $"https://api.vk.com/method/users.get?access_token={accessToken}&version=5.74&fields=photo_400_orig&name_case=Nom");



            var responseString = await response.Content.ReadAsStringAsync();
            var profileInfo = JsonConvert.DeserializeAnonymousType(responseString, new UserPostModel());

            var userInfo = profileInfo.response?.FirstOrDefault();

            if (userInfo == null)
            {
                return null;
            }

            var user = _userRepository.GetByVkId(userInfo.uid);

            if (user == null)
            {
                user = new User()
                {
                    VkId = userInfo.uid,
                    FirstName = userInfo.first_name,
                    LastName = userInfo.last_name,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow,
                    AvatarPath = profileInfo.response.First().photo_100
                };
                _userRepository.Create(user);
            }
            else
            {
                user.AvatarPath = profileInfo.response.First().photo_400_orig;
                _userRepository.Update(user);
            }

            return profileInfo;
        }
    }
}
