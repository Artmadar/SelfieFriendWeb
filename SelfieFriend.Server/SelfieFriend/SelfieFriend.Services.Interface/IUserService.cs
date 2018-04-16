using SelfieFriend.Domain.Core;

namespace SelfieFriend.Services.Interface
{
    public interface IUserService
    {
        User GetUserByVkId(int id);
    }
}
