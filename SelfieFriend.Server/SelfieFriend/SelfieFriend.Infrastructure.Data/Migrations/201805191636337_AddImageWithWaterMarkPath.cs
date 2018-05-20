namespace SelfieFriend.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageWithWaterMarkPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OfferingPhotoes", "ImageWithWaterMarkPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OfferingPhotoes", "ImageWithWaterMarkPath");
        }
    }
}
