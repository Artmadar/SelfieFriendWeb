using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieFriend.Services.Interface.Models
{
    public class UserPostModel
    {
        public List<response> response { get; set; }
    }

    public class response
    {
        public int uid { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string photo_100 { get; set; }
        public string photo_400_orig { get; set; }


    }
}
