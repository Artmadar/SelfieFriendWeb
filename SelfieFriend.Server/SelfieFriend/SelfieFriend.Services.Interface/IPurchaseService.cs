using System.Collections.Generic;

namespace SelfieFriend.Services.Interface
{
    public interface IPurchaseService
    {
        IEnumerable<object> GetCustomerPurchasesByVkId(int id);
        IEnumerable<object> GetSellerPurchasesByVkId(int id);
        void Create(string photoPath, int inquiryId, int vkId);
        void Pay(int inquiryId, int vkId);
        string GetPhoto(int applicationId);
    }
}
