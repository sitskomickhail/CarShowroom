namespace CarShowroom.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Editing_resolution_entity_model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resolutions", "EmployeeSuccess_EquipmentSuccessChance", c => c.Int(nullable: false));
            AddColumn("dbo.Resolutions", "EmployeeSuccess_EquipmentFailChance", c => c.Int(nullable: false));
            AddColumn("dbo.Resolutions", "EmployeeFail_EquipmentSuccessChance", c => c.Int(nullable: false));
            AddColumn("dbo.Resolutions", "EmployeeFail_EquipmentFailChance", c => c.Int(nullable: false));
            DropColumn("dbo.Resolutions", "EmployeeHiringChance");
            DropColumn("dbo.Resolutions", "EquipmentPurchaseChance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resolutions", "EquipmentPurchaseChance", c => c.Int(nullable: false));
            AddColumn("dbo.Resolutions", "EmployeeHiringChance", c => c.Int(nullable: false));
            DropColumn("dbo.Resolutions", "EmployeeFail_EquipmentFailChance");
            DropColumn("dbo.Resolutions", "EmployeeFail_EquipmentSuccessChance");
            DropColumn("dbo.Resolutions", "EmployeeSuccess_EquipmentFailChance");
            DropColumn("dbo.Resolutions", "EmployeeSuccess_EquipmentSuccessChance");
        }
    }
}
