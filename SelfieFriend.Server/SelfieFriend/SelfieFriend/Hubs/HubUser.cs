using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfieFriend.Hubs
{
    public class HubUser
    {
        public int Id { get; set; }
        public string ConnectionId { get; set; }
    }
}