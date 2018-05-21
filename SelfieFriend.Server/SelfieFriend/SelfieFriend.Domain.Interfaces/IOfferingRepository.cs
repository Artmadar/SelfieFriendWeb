using System.Collections.Generic;
using SelfieFriend.Domain.Core;

namespace SelfieFriend.Domain.Interfaces
{
    public interface IOfferingRepository
    {
        List<Offering> GetList(OfferingType offeringType);
        List<Offering> GetRangeList(int startPosition,int count,int vkId, OfferingType offeringType);
        List<Offering> GetListWithUsersAndPhotos(OfferingType offeringType);
        List<Offering> GetListWithUsersAndPhotosByUserVkId(int vkid, OfferingType offeringType);
        List<Offering> GetListWithSerach(OfferingType offeringType, string search, int CategoryId = 0);
        Offering Get(int id);
        Offering GetByPhotoPath(string path);
        void Create(Offering item);
        void Update(Offering item);
        void Delete(int id);
    }
}
