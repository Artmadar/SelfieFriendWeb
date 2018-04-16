using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieFriend.Services.Interface.Models
{
    public class UserInquiries
    {
        public int ApplicationId { get; set; }
        public string OfferingUserFirstName { get; set; }
        public string OfferingPhoto { get; set; }
        public string OfferingUserLastName { get; set; }
        public bool ReadyToBay { get; set; }
        public bool ReadyToDownload { get; set; }
        public string Price { get; set; }
        public string Text { get; set; }
        public string AvatarPath { get; set; }
        public string Title { get; set; }
    }
}
