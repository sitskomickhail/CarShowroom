namespace CarShowroom.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_in_user_client_relationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Number", c => c.String());
            AddColumn("dbo.Clients", "User_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.Clients", "User_Id");
            AddForeignKey("dbo.Clients", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "User_Id", "dbo.Users");
            DropIndex("dbo.Clients", new[] { "User_Id" });
            DropColumn("dbo.Clients", "User_Id");
            DropColumn("dbo.Clients", "Number");
        }
    }
}
