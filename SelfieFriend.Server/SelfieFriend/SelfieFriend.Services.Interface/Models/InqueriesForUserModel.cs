using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieFriend.Services.Interface.Models
{
    public class InqueriesForUserModel
    {
        public int ApplicationId { get; set; }
        public bool Uploaded { get; set; }
        public string OfferingPhoto { get; set; }
        public string ApplicationUserFirstName { get; set; }
        public string ApplicationUserLastName { get; set; }
        public string Price { get; set; }
        public string Text { get; set; }
        public string AvatarPath { get; set; }
        public string Title { get; set; }
    }
}
