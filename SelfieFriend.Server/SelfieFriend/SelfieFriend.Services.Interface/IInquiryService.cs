using System.Collections.Generic;

namespace SelfieFriend.Services.Interface
{
    public interface IInquiryService
    {
        bool IsExistInquiryOnOffering(int vkId, int offeringId);
        void DeleteInquiryByOfferingId(int vkId, int offeringId);
        object Create(int offeringId, int vkId, string text);
        IEnumerable<object> GetInquiriesListForUser(string hostPort,int vkId);
        IEnumerable<object> GetUserInquiries(string hostPort, int vkId);

    }
}
