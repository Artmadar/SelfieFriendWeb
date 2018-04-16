using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SelfieFriend.Domain.Core
{
    public class Inquiry: BaseSelfieFriendEntity
    {
        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int OfferingId { get; set; }

        public Offering Offering { get; set; }


        public string Text { get; set; }

        public bool Closed { get; set; }

        public Purchase Purchase { get; set; }

        public IEnumerable<Message> Messages { get; set; }

        public Inquiry()
        {
            Messages=new List<Message>();
        }

    }
}
