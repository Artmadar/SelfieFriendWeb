using System.Collections.Generic;
using SelfieFriend.Domain.Core;

namespace SelfieFriend.Domain.Interfaces
{
    public interface IOfferingRepository
    {
        List<Offering> GetList();
        List<Offering> GetRangeList(int startPosition,int count,int vkId);
        List<Offering> GetListWithUsersAndPhotos();
        List<Offering> GetListWithUsersAndPhotosByUserVkId(int vkid);
        Offering Get(int id);
        Offering GetByPhotoPath(string path);
        void Create(Offering item);
        void Update(Offering item);
        void Delete(int id);
    }
}
