namespace SelfieFriend.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBuyEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserBuyOfferings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfferingId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Offerings", t => t.OfferingId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.OfferingId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBuyOfferings", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserBuyOfferings", "OfferingId", "dbo.Offerings");
            DropIndex("dbo.UserBuyOfferings", new[] { "UserId" });
            DropIndex("dbo.UserBuyOfferings", new[] { "OfferingId" });
            DropTable("dbo.UserBuyOfferings");
        }
    }
}
