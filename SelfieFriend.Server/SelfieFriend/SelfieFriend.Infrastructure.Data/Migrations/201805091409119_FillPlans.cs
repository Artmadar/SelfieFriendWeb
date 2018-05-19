namespace SelfieFriend.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillPlans : DbMigration
    {
        public override void Up()
        {
            Sql(@"Insert Into [SubscribePlans] (MonthCount, Price) VALUES
                        (1,3000),
                        (3, 6000),
                        (12, 10000)");
        }
        
        public override void Down()
        {
            Sql(@"Delete from SubscribePlans");
        }
    }
}
