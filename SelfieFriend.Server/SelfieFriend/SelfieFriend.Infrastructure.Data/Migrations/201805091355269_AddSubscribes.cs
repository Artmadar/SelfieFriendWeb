namespace SelfieFriend.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubscribes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubscribePlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MonthCount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubscribePlans");
        }
    }
}
