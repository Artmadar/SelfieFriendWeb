namespace SelfieFriend.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillOfferingsCategories : DbMigration
    {
        public override void Up()
        {
            Sql(@"Insert Into [OfferingCategories] (Name) VALUES
                        ('Interior'),
                        ('Auto'),
                        ('Woman'),
                        ('Art'),
                        ('Abstract')");
        }
        
        public override void Down()
        {
            Sql(@"delete from [OfferingCategories]");
        }
    }
}
