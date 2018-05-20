using SelfieFriend.Domain.Core;
using System.Collections.Generic;
using System.Linq;

namespace SelfieFriend.Infrastructure.Data
{
    public class UserBuyOfferingReporsitory : Repository<UserBuyOffering>
    {
        public UserBuyOfferingReporsitory(SelfieFriendContext db) : base(db)
        {
        }
 
        public UserBuyOffering GetByUserIdAndOfferingId(int userId, int offeringId)
        {
            var query = _db.UserBuyOfferings.FirstOrDefault(x => x.UserId == userId && x.OfferingId == offeringId);
            return query;
        }

        public List<UserBuyOffering> GetListByUserId(int userId)
        {
            var query = _db.UserBuyOfferings.Where(x => x.UserId == userId).ToList();
            return query;
        }

    }
}
