namespace SelfieFriend.Domain.Core
{
    public class SubscribePlan:BaseSelfieFriendEntity
    {
        public int MonthCount { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int PhotoToBuyCount { get; set; }
    }
}
