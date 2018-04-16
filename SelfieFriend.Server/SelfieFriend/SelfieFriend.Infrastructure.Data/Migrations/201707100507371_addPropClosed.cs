namespace SelfieFriend.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPropClosed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offerings", "Closed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offerings", "Closed");
        }
    }
}
