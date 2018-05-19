using SelfieFriend.Domain.Core;
using System.Linq;

namespace SelfieFriend.Infrastructure.Data
{
    public class PurchasedSubscribeRepository : Repository<PurchasedSubscribe>
    {
        public PurchasedSubscribeRepository(SelfieFriendContext db) : base(db)
        {
        }   
        
        public PurchasedSubscribe GetByUserId(int userId)
        {
            var subscribe = _db.PurchasedSubscribes.FirstOrDefault(x => x.UserId == userId);
            return subscribe;
        }

    }
}
