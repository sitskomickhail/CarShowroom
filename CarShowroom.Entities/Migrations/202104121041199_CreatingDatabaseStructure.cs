namespace CarShowroom.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingDatabaseStructure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Maintenances",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        MaintainFrom = c.DateTime(),
                        MaintainUntil = c.DateTime(),
                        RepairingHours = c.Double(),
                        TotalCost = c.Decimal(precision: 18, scale: 2),
                        Client_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SaleTime = c.DateTime(),
                        TotalCost = c.Decimal(precision: 18, scale: 2),
                        PaymentMethod = c.String(),
                        PaymentAbove = c.DateTime(),
                        Client_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.Client_Id);
            
            DropColumn("dbo.Vehicles", "Capacity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "Capacity", c => c.Int());
            DropForeignKey("dbo.Sales", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Maintenances", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Sales", "Id", "dbo.Vehicles");
            DropForeignKey("dbo.Maintenances", "Id", "dbo.Vehicles");
            DropIndex("dbo.Sales", new[] { "Client_Id" });
            DropIndex("dbo.Sales", new[] { "Id" });
            DropIndex("dbo.Maintenances", new[] { "Client_Id" });
            DropIndex("dbo.Maintenances", new[] { "Id" });
            DropTable("dbo.Sales");
            DropTable("dbo.Maintenances");
            DropTable("dbo.Clients");
        }
    }
}
