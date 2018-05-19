namespace SelfieFriend.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldToSubscribes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchasedSubscribes", "PhotoToBuyCount", c => c.Int(nullable: false));
            AddColumn("dbo.SubscribePlans", "Description", c => c.String());
            AddColumn("dbo.SubscribePlans", "PhotoToBuyCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubscribePlans", "PhotoToBuyCount");
            DropColumn("dbo.SubscribePlans", "Description");
            DropColumn("dbo.PurchasedSubscribes", "PhotoToBuyCount");
        }
    }
}
