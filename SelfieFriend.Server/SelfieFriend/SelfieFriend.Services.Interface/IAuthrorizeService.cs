using System.Threading.Tasks;

namespace SelfieFriend.Services.Interface
{
    public interface IAuthrorizeService
    {
        Task<object> Authorize(string accessToken);
    }
}
