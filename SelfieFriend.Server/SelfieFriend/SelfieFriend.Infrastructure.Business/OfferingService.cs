using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using SelfieFriend.Domain.Core;
using SelfieFriend.Domain.Interfaces;
using SelfieFriend.Services.Interface;
using SelfieFriend.Services.Interface.Models;

namespace SelfieFriend.Infrastructure.Business
{
    public class OfferingService:IOfferingService
    {

        private readonly IOfferingRepository _offeringRepository;
        private readonly IInquiryService _inquiryService;
        private readonly IUserService _userService;

        public OfferingService(IOfferingRepository offeringRepository,IInquiryService inquiryService,IUserService userService)
        {
            _offeringRepository = offeringRepository;
            _inquiryService = inquiryService;
            _userService = userService;
        }


        public List<OfferingPostModel> Get(string hostPort, int vkId, OfferingType offeringType)
        {
            var offerings = _offeringRepository.GetListWithUsersAndPhotos(offeringType);//.Where(o=>o.User.VkId!=vkId).ToList();
            var offeringModels = CreateOfferingPostModelsRevers(offerings, hostPort, vkId);

            return offeringModels;
        }


        public List<OfferingPostModel> GetWithSerach(OfferingType offeringType,int vkId, string hostPort, string search, int CategoryId = 0)
        {
            var offerings = _offeringRepository.GetListWithSerach(offeringType, search, CategoryId);//.Where(o => o.User.VkId != vkId).ToList();
            var offeringModels = CreateOfferingPostModelsRevers(offerings, hostPort, vkId);
            return offeringModels;
        }

        public List<OfferingPostModel> Get(string hostPort, int vkId, int startposition, int count, OfferingType offeringType)
        {

            var offerings = _offeringRepository.GetRangeList(startposition, count, vkId,offeringType)
                .Where(o => o.User.VkId != vkId).ToList();
            var offeringModels = CreateOfferingPostModels(offerings, hostPort, vkId);

            return offeringModels;
           

        }


        public List<OfferingPostModel> GetUserOfferings(string hostPort, int vkId, OfferingType offeringType)
        {
            var offerings = _offeringRepository.GetListWithUsersAndPhotos(offeringType).Where(o => o.User.VkId == vkId).ToList();
            var offeringModels = CreateOfferingPostModelsRevers(offerings, hostPort, vkId);

            return offeringModels;
        }

        public OfferingPostModel GetOfferingByFilePath(string path,string hostPort)
        {
           var offering = _offeringRepository.GetByPhotoPath(path);

            var model = new OfferingPostModel()
            {
                OfferingId = offering.Id,
                FirstName = offering.User.FirstName,
                LastName = offering.User.LastName,
                ImagePath = Path.Combine("http://", hostPort + @"/" + offering.OfferingPhoto.ImagePath),
                Title = offering.Title,
                Price = offering.Price.ToString(CultureInfo.InvariantCulture),
                DateCreated = offering.DateCreated,
                AvatarPath = offering.User.AvatarPath,
                Description = offering.Desctiption,

                Checked = false
            };

            return model;


        }

        //Need to test
        public void OfferChange(int offeringId, string filePath, int vkId, decimal price, string description, string title, int categoryId)
        {
            var offering = _offeringRepository.Get(offeringId);

            if (offering==null || offering.User.VkId!=vkId)return;
            
            

            offering.OfferingPhoto.ImagePath = filePath;
            offering.Price = price;
            offering.Desctiption = description;
            offering.Title = title;
            if (categoryId != 0)
            {
                offering.OfferingCategoryId = categoryId;
            }
           
            
            _offeringRepository.Update(offering);

        }

        public void OfferChange(int offeringId, int vkId, decimal price, string description, string title,int categoryId)
        {
            var offering = _offeringRepository.Get(offeringId);

            if (offering == null || offering.User.VkId != vkId) return;

            
            offering.Price = price;
            offering.Desctiption = description;
            offering.Title = title;

            if (categoryId != 0)
            {
                offering.OfferingCategoryId = categoryId;
            }

            _offeringRepository.Update(offering);
        }

        //need to test
        public void Create(string filePath, int vkId, decimal price, string description, string title, int categoryId,OfferingType offeringType)
        {
            var offeringTypeId = (int)offeringType;
            var offering = new Offering();
            var photo = new OfferingPhoto();

            photo.ImagePath = filePath;
            offering.UserId = _userService.GetUserByVkId(vkId).Id;
            offering.OfferingPhoto = photo;
            offering.Price = price;
            offering.Desctiption = description;
            offering.Title = title;
            offering.DateCreated = DateTime.UtcNow;
            offering.OfferingTypeId = offeringTypeId;
            if (categoryId != 0)
            {
                offering.OfferingCategoryId = categoryId;
            }

            _offeringRepository.Create(offering);

        }

        public void CloseOffering(int vkId, int offeringId)
        {
            var user = _userService.GetUserByVkId(vkId);
            var offering = _offeringRepository.Get(offeringId);
            if (user == null || offering ==null)
                return;

            if (offering.UserId != user.Id)return;

            offering.Closed = true;

            _offeringRepository.Update(offering);

        }


        private List<OfferingPostModel> CreateOfferingPostModelsRevers(List<Offering> offerings,string hostPort,int vkId)
        {
            var offeringModels = new List<OfferingPostModel>();

            foreach (var offering in offerings)
            {
                string path = offering.User.AvatarPath;
                if (string.IsNullOrEmpty(path))
                {
                    path = Path.Combine("http://", hostPort + @"/" + "Content/Avatars/size50/camera_50.png");
                }



                offeringModels.Add(item: new OfferingPostModel()
                {
                    OfferingId = offering.Id,
                    FirstName = offering.User.FirstName,
                    LastName = offering.User.LastName,
                    ImagePath = Path.Combine("http://", hostPort + @"/" + offering.OfferingPhoto.ImagePath),
                    Title = offering.Title,
                    Price = offering.Price.ToString(CultureInfo.InvariantCulture),
                    DateCreated = offering.DateCreated,
                    AvatarPath = path,
                    Description = offering.Desctiption,
                    CategoryId = offering.OfferingCategoryId ?? 0,
                    CategotyName = offering.OfferingCategory != null ? offering.OfferingCategory.Name : "NoCategory",
                    Checked = _inquiryService.IsExistInquiryOnOffering(vkId, offering.Id),
                });
            }

            offeringModels.Reverse();

            return offeringModels;
        }

        private List<OfferingPostModel> CreateOfferingPostModels(List<Offering> offerings, string hostPort, int vkId)
        {
            var offeringModels = new List<OfferingPostModel>();

            foreach (var offering in offerings)
            {
                string path = offering.User.AvatarPath;
                if (string.IsNullOrEmpty(path))
                {
                    path = Path.Combine("http://", hostPort + @"/" + "Content/Avatars/size50/camera_50.png");
                }



                var offeringPostModel = new OfferingPostModel();
                offeringPostModel.OfferingId = offering.Id;
                offeringPostModel.FirstName = offering.User.FirstName;
                offeringPostModel.LastName = offering.User.LastName;
     

                offeringPostModel.ImagePath = Path.Combine("http://", hostPort + @"/" + offering.OfferingPhoto.ImagePath);
                offeringPostModel.Title = offering.Title;
                offeringPostModel.Price = offering.Price.ToString(CultureInfo.InvariantCulture);
                offeringPostModel.DateCreated = offering.DateCreated;
                offeringPostModel.AvatarPath = path;
                offeringPostModel.Description = offering.Desctiption;

                offeringPostModel.Checked = _inquiryService.IsExistInquiryOnOffering(vkId, offering.Id);

                offeringPostModel.CategotyName = offering.OfferingCategory != null ? offering.OfferingCategory.Name : "NoCategory";

                offeringModels.Add(offeringPostModel);
            }
            return offeringModels;
        }

    }
}
