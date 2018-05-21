namespace SelfieFriend.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OfferingToOfferingCategoryRelations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offerings", "OfferingCategoryId", c => c.Int());
            CreateIndex("dbo.Offerings", "OfferingCategoryId");
            AddForeignKey("dbo.Offerings", "OfferingCategoryId", "dbo.OfferingCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offerings", "OfferingCategoryId", "dbo.OfferingCategories");
            DropIndex("dbo.Offerings", new[] { "OfferingCategoryId" });
            DropColumn("dbo.Offerings", "OfferingCategoryId");
        }
    }
}
