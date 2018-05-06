using System.Collections.Generic;
using SelfieFriend.Domain.Core;
using SelfieFriend.Services.Interface.Models;


namespace SelfieFriend.Services.Interface
{
    public interface IOfferingService
    {
        List<OfferingPostModel> Get(string hostPort, int vkId, OfferingType offeringType);
        List<OfferingPostModel> Get(string hostPort, int vkId,int startposition,int count, OfferingType offeringType);
        List<OfferingPostModel> GetUserOfferings(string hostPort, int vkId, OfferingType offeringType);
        OfferingPostModel GetOfferingByFilePath(string path,string hostPort);
        void OfferChange(int offeringId,string filePath,int vkId, decimal price,string description, string title);
        void OfferChange(int offeringId, int vkId, decimal price, string description, string title);
        void Create(string filePath, int vkId, decimal price, string description, string title, OfferingType offeringType);
        void CloseOffering(int vkId, int offeringId);
    }
}
