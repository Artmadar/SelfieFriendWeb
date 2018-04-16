using System.Collections.Generic;
using System.Linq;
using SelfieFriend.Domain.Interfaces;
using SelfieFriend.Services.Interface;

namespace SelfieFriend.Infrastructure.Business
{
    public class PurchaseService:IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public IEnumerable<object> GetCustomerPurchasesByVkId(int id)
        {
            return _purchaseRepository.GetCustomerPurchasesByVkId(id).ToList();
        }

        public IEnumerable<object> GetSellerPurchasesByVkId(int id)
        {
            return _purchaseRepository.GetSellerPurchasesByVkId(id).ToList();
        }

        public void Create(string photoPath, int inquiryId, int vkId)
        {
            _purchaseRepository.Create(photoPath, inquiryId, vkId);
        }

        public void Pay(int applicationId, int vkId)
        {
            _purchaseRepository.Pay(applicationId, vkId);
        }

        public string GetPhoto(int applicationId)
        {
            return _purchaseRepository.GetPhoto(applicationId);
        }
    }
}
