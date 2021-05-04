namespace CarShowroom.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_Status_column_in_Sale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "Status", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "Status");
        }
    }
}
