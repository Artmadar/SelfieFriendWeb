using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SelfieFriend.Domain.Core
{
    public class User: BaseSelfieFriendEntity
    {
        

        [Required]
        public int VkId { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string AvatarPath { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public string Sex { get; set; }

        public string Site { get; set; }

        public string AboutHim { get; set; }

        public IEnumerable<Offering> Offerings { get; set; }

        public IEnumerable<Inquiry> Inquiries { get; set; }

        public User()
        {
            Offerings=new List<Offering>();
            Inquiries=new List<Inquiry>();
        }
    }
}
