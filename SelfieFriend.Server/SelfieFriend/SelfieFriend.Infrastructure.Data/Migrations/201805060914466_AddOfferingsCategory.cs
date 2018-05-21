namespace SelfieFriend.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOfferingsCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OfferingCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Offerings", "OfferingTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offerings", "OfferingTypeId");
            DropTable("dbo.OfferingCategories");
        }
    }
}
