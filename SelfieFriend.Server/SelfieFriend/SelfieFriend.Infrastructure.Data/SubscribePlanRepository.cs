using SelfieFriend.Domain.Core;
namespace SelfieFriend.Infrastructure.Data
{
    public class SubscribePlanRepository : Repository<SubscribePlan>
    {
        public SubscribePlanRepository(SelfieFriendContext db) : base(db)
        { 
        }
    }
}
