using SelfieFriend.Domain.Core;

namespace SelfieFriend.Infrastructure.Data
{
    public class OfferingsCategoryRepository : Repository<OfferingCategory>
    {
        public OfferingsCategoryRepository(SelfieFriendContext db):base(db)
        { 

        }
    }
}
