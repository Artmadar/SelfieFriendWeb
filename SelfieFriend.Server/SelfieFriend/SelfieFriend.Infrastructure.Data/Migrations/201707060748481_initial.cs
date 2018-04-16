namespace SelfieFriend.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inquiries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        OfferingId = c.Int(nullable: false),
                        Text = c.String(),
                        Closed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Offerings", t => t.OfferingId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.OfferingId);
            
            CreateTable(
                "dbo.Offerings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Title = c.String(),
                        Desctiption = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                //.ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OfferingPhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ImagePath = c.String(nullable: false),
                        ImageSize = c.Int(),
                        Latitude = c.Double(),
                        Logitude = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                //.ForeignKey("dbo.Offerings", t => t.Id)
                .ForeignKey("dbo.Offerings", t => t.Id, cascadeDelete: false)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VkId = c.Int(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        AvatarPath = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        Sex = c.String(),
                        Site = c.String(),
                        AboutHim = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Bought = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inquiries", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PurchasePhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ImagePath = c.String(nullable: false),
                        ImageSize = c.Int(),
                        Latitude = c.Double(),
                        Logitude = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                //.ForeignKey("dbo.Purchases", t => t.Id)
                .ForeignKey("dbo.Purchases", t => t.Id, cascadeDelete: false)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inquiries", "UserId", "dbo.Users");
            DropForeignKey("dbo.PurchasePhotoes", "Id", "dbo.Purchases");
            DropForeignKey("dbo.Purchases", "Id", "dbo.Inquiries");
            DropForeignKey("dbo.Inquiries", "OfferingId", "dbo.Offerings");
            DropForeignKey("dbo.Offerings", "UserId", "dbo.Users");
            DropForeignKey("dbo.OfferingPhotoes", "Id", "dbo.Offerings");
            DropIndex("dbo.PurchasePhotoes", new[] { "Id" });
            DropIndex("dbo.Purchases", new[] { "Id" });
            DropIndex("dbo.OfferingPhotoes", new[] { "Id" });
            DropIndex("dbo.Offerings", new[] { "UserId" });
            DropIndex("dbo.Inquiries", new[] { "OfferingId" });
            DropIndex("dbo.Inquiries", new[] { "UserId" });
            DropTable("dbo.PurchasePhotoes");
            DropTable("dbo.Purchases");
            DropTable("dbo.Users");
            DropTable("dbo.OfferingPhotoes");
            DropTable("dbo.Offerings");
            DropTable("dbo.Inquiries");
        }
    }
}
