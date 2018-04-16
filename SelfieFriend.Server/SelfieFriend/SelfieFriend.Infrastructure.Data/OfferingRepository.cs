using System;
using System.Collections.Generic;
using System.Linq;
using SelfieFriend.Domain.Core;
using SelfieFriend.Domain.Interfaces;
using System.Data.Entity;

namespace SelfieFriend.Infrastructure.Data
{
    public class OfferingRepository : IOfferingRepository
    {
        private readonly SelfieFriendContext _db;

        public OfferingRepository(SelfieFriendContext db)
        {
            _db = db;
        }


        public List<Offering> GetList()
        {
            return _db.Offerings.Where(o => o.Closed == false).ToList();
        }

        public List<Offering> GetRangeList(int startPosition, int count, int vkId)
        {
            if (count <= 0)
                throw new ArgumentException("param count can not be <= 0");


            var offeringsCount = _db.Offerings.Count(o => o.Closed == false && o.User.VkId != vkId);

            if (offeringsCount < startPosition + count)
            {



                if (offeringsCount > startPosition && offeringsCount < count)
                {
                    return _db.Offerings
                        .Include(o => o.User)
                        .Include(o => o.OfferingPhoto)
                        .Where(o => o.Closed == false && o.User.VkId != vkId)
                        .OrderByDescending(o => o.Id).Skip(startPosition).Take(offeringsCount - startPosition - 1)
                        .ToList();
                }


                if (offeringsCount <= startPosition)
                {
                    return new List<Offering>();


                }


                

                if (offeringsCount < count)
                {
                    return new List<Offering>();
                }


                return _db.Offerings
                    .Include(o => o.User)
                    .Include(o => o.OfferingPhoto)
                    .Where(o => o.Closed == false && o.User.VkId != vkId)
                    .OrderByDescending(o=>o.Id).Skip(startPosition).Take(offeringsCount-startPosition)
                    .ToList();

            }


           

            return _db.Offerings
                .Include(o => o.User)
                .Include(o => o.OfferingPhoto)
                .Where(o => o.Closed == false && o.User.VkId != vkId)
                .OrderByDescending(o => o.Id).Skip(startPosition).Take(count)
                .ToList();





            
        }

        public List<Offering> GetListWithUsersAndPhotos()
        {
            return _db.Offerings
                .Include(o => o.User)
                .Include(o => o.OfferingPhoto)
                .Where(i => i.Closed == false)
                .ToList();
        }

        public List<Offering> GetListWithUsersAndPhotosByUserVkId(int vkid)
        {
            return _db.Offerings
                .Include(o => o.User)
                .Include(o => o.OfferingPhoto)
                .Where(o => o.User.VkId == vkid && o.Closed == false)
                .ToList();
        }

        public Offering Get(int id)
        {
            return _db.Offerings.Include(o => o.OfferingPhoto)
                .Include(o => o.User)
                .FirstOrDefault(o => o.Id == id);
        }

        public Offering GetByPhotoPath(string path)
        {
            return _db.Offerings
                .Include(o => o.OfferingPhoto)
                .Include(o=>o.User)
                .FirstOrDefault(o => o.OfferingPhoto.ImagePath == path);

        }

        public void Create(Offering item)
        {
            _db.Offerings.Add(item);
            _db.SaveChanges();
        }

        public void Update(Offering item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var offerings = _db.Offerings.Find(id);
            if (offerings == null) return;
            _db.Offerings.Remove(offerings);
            _db.SaveChanges();
        }
    }
}
