using System.Collections.Generic;

namespace SelfieFriend.Domain.Core
{
    public class UserBuyOffering: BaseSelfieFriendEntity
    {
        public UserBuyOffering()
        {

        }

        public UserBuyOffering(int userId , int offeringId)
        {
            UserId = userId;
            OfferingId = offeringId;
        }

        public int OfferingId { get; set; }

        public int UserId { get; set; }

        public Offering Offering { get; set; }

        public User User { get; set; }

    }
}
