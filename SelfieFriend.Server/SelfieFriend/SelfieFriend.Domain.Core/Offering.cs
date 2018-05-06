using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SelfieFriend.Domain.Core
{
    public class Offering: BaseSelfieFriendEntity
    {

        public OfferingPhoto OfferingPhoto { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        public string Title { get; set; }

        public string Desctiption { get; set; }

        public decimal Price { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<Inquiry> Inquiries { get; set; }

        public int OfferingTypeId { get; set; }



        public bool Closed { get; set; }

        public Offering()
        {
            Inquiries=new List<Inquiry>();
        }
    }

    public enum OfferingType
    {
        Selfie=0,
        Sale=1
    }

}
