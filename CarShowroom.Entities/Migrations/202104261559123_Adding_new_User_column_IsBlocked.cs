namespace CarShowroom.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_new_User_column_IsBlocked : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsBlocked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsBlocked");
        }
    }
}
