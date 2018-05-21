using SelfieFriend.Domain.Core;
using SelfieFriend.Domain.Interfaces;
using SelfieFriend.Services.Interface;
using SelfieFriend.Services.Interface.Models;

namespace SelfieFriend.Infrastructure.Business
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        /// <summary>
        /// Получение пользователя по id из vk.com
        /// </summary>
        /// <param name="id">id из vk.com </param>
        /// <returns>Возвращает пользователя User, если такой пользователь существует в бд с таким vkId</returns>
        public User GetUserByVkId(int id)
        {
            return _userRepository.GetByVkId(id);
        }

        public void ChangeUserInfo(UserInfoModel userInfoModel, int vkId)
        {
            var user = _userRepository.GetByVkId(vkId);

            user.Email = userInfoModel.Email;
            user.Phone = userInfoModel.Phone;
            user.FirstName = userInfoModel.FirstName;
            user.LastName = userInfoModel.LastName;
            user.AboutHim = userInfoModel.AboutHim;
            user.Site = userInfoModel.Site;

            _userRepository.Update(user);
        }

    }
}
