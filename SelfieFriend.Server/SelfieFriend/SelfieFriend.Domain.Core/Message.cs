using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieFriend.Domain.Core
{
    public class Message:BaseSelfieFriendEntity
    {
        
        public int InquiryId { get; set; }
        public Inquiry Inquiry { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime DateCreated { get; set; }
        public string Text { get; set; }
    }
}
