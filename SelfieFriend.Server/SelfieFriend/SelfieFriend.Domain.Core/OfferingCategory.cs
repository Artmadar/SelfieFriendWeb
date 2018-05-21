using System.Collections.Generic;

namespace SelfieFriend.Domain.Core
{
    public class OfferingCategory:BaseSelfieFriendEntity
    {
        public OfferingCategory()
        {
            Offerings = new List<Offering>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Offering> Offerings { get; set; }

    }
}
