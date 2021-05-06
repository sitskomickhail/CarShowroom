namespace CarShowroom.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingDatabaseSrtucture_Vehicle_Sales_Maintenances : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Maintenances", "Id", "dbo.Vehicles");
            DropForeignKey("dbo.Sales", "Id", "dbo.Vehicles");
            DropIndex("dbo.Maintenances", new[] { "Id" });
            DropIndex("dbo.Sales", new[] { "Id" });
            AddColumn("dbo.Maintenances", "Vehicle_Id", c => c.Guid(nullable: false));
            AddColumn("dbo.Sales", "Vehicle_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.Maintenances", "Vehicle_Id");
            CreateIndex("dbo.Sales", "Vehicle_Id");
            AddForeignKey("dbo.Maintenances", "Vehicle_Id", "dbo.Vehicles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sales", "Vehicle_Id", "dbo.Vehicles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Maintenances", "Vehicle_Id", "dbo.Vehicles");
            DropIndex("dbo.Sales", new[] { "Vehicle_Id" });
            DropIndex("dbo.Maintenances", new[] { "Vehicle_Id" });
            DropColumn("dbo.Sales", "Vehicle_Id");
            DropColumn("dbo.Maintenances", "Vehicle_Id");
            CreateIndex("dbo.Sales", "Id");
            CreateIndex("dbo.Maintenances", "Id");
            AddForeignKey("dbo.Sales", "Id", "dbo.Vehicles", "Id");
            AddForeignKey("dbo.Maintenances", "Id", "dbo.Vehicles", "Id");
        }
    }
}
