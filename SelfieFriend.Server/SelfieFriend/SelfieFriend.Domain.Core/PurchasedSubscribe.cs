using System;
namespace SelfieFriend.Domain.Core
{
    public class PurchasedSubscribe:BaseSelfieFriendEntity
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PhotoToBuyCount { get; set; }
    }
}
