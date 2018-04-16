using System.Collections.Generic;
using SelfieFriend.Domain.Core;

namespace SelfieFriend.Domain.Interfaces
{
    public interface IPurchaseRepository
    {
        List<Purchase> GetUserList();
        Purchase GetPurchase(int id);
        List<Purchase> GetCustomerPurchasesByVkId(int id);
        List<Purchase> GetSellerPurchasesByVkId(int id);
        void Create(Purchase item);
        void Create(string photoPath, int inquiryId, int vkId);
        bool Bought(int id);
        void Update(Purchase item);
        void Delete(int id);
        void Pay(int applicationId, int vkId);
        string GetPhoto(int applicationId);
    }
}
