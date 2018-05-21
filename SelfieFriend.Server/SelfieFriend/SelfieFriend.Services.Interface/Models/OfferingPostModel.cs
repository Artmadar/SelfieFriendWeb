using System;

namespace SelfieFriend.Services.Interface.Models
{
    public class OfferingPostModel
    {
        public int OfferingId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImagePath { get; set; }

        public string Title { get; set; }

        public string Price { get; set; }

        public DateTime? DateCreated { get; set; }

        public string AvatarPath { get; set; }

        public string Description { get; set; }

        public string CategotyName { get; set; }
        
        public int CategoryId { get; set; }

        public bool Checked { get; set; }
    }
}
