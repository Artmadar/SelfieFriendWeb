using SelfieFriend.Domain.Core;
using SelfieFriend.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace SelfieFriend.Infrastructure.Business
{
    public class OfferingsCategoryService
    {
        private readonly OfferingsCategoryRepository _offeringsCategoryRepository;
        public OfferingsCategoryService(OfferingsCategoryRepository offeringsCategoryRepository)
        {
            _offeringsCategoryRepository = offeringsCategoryRepository;
        }


        public List<OfferingCategory> GetList()
        {
            return _offeringsCategoryRepository.GetList().ToList();
        }
        
        public void Create(string name, string description)
        {
            var offeringCategory = new OfferingCategory()
            {
                Name = name,
                Description = description
            };

            _offeringsCategoryRepository.Create(offeringCategory);
        }

    }
}
