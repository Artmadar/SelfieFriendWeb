namespace SelfieFriend.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurchasedSubscribe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchasedSubscribes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchasedSubscribes", "UserId", "dbo.Users");
            DropIndex("dbo.PurchasedSubscribes", new[] { "UserId" });
            DropTable("dbo.PurchasedSubscribes");
        }
    }
}
