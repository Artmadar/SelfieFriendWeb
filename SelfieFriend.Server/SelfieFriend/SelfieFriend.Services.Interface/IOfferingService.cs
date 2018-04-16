using System.Collections.Generic;
using SelfieFriend.Services.Interface.Models;


namespace SelfieFriend.Services.Interface
{
    public interface IOfferingService
    {
        List<OfferingPostModel> Get(string hostPort, int vkId);
        List<OfferingPostModel> Get(string hostPort, int vkId,int startposition,int count);
        List<OfferingPostModel> GetUserOfferings(string hostPort, int vkId);
        OfferingPostModel GetOfferingByFilePath(string path,string hostPort);
        void OfferChange(int offeringId,string filePath,int vkId, decimal price,string description, string title);
        void OfferChange(int offeringId, int vkId, decimal price, string description, string title);
        void Create(string filePath, int vkId, decimal price, string description, string title);
        void CloseOffering(int vkId, int offeringId);
    }
}
