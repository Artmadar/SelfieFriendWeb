using SelfieFriend.Domain.Core;
using SelfieFriend.Services.Interface.Models;

namespace SelfieFriend.Services.Interface
{
    public interface IUserService
    {
        User GetUserByVkId(int id);
        void ChangeUserInfo(UserInfoModel userInfoModel, int vkId);
    }
}
