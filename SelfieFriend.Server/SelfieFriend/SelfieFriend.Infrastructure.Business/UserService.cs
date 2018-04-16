using SelfieFriend.Domain.Core;
using SelfieFriend.Domain.Interfaces;
using SelfieFriend.Services.Interface;

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
    }
}
