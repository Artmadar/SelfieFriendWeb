using System.Data.Entity;
using SelfieFriend.Domain.Core;

namespace SelfieFriend.Infrastructure.Data
{
    public class SelfieFriendContext : DbContext
    {
        public SelfieFriendContext() : base("SelfieFriendContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Offering> Offerings { get; set; }

        public DbSet<Inquiry> Inquiries { get; set; }

        public DbSet<OfferingPhoto> OfferingPhotos { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<PurchasePhoto> PurchasePhotos { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<OfferingCategory> OfferingCategories { get; set; }

        public DbSet<PurchasedSubscribe> PurchasedSubscribes { get; set; }

        public DbSet<SubscribePlan> SubscribePlans { get; set; }

        public DbSet<UserBuyOffering> UserBuyOfferings { get; set; }

    }
}
