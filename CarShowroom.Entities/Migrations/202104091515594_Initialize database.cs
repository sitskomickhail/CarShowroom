using System.Data.Entity.Migrations.Model;
using CarShowroom.Entities.DatabaseModels;

namespace CarShowroom.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initializedatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RoleType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Login = c.String(),
                        PasswordHash = c.String(),
                        Salt = c.String(),
                        Role_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Model = c.String(),
                        Mark = c.String(),
                        Salable = c.Boolean(),
                        Capacity = c.Int(),
                        Cost = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
