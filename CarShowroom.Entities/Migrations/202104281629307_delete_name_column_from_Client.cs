namespace CarShowroom.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_name_column_from_Client : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clients", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Name", c => c.String());
        }
    }
}
