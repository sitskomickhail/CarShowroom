namespace CarShowroom.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creating_resolution_instance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resolutions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        EmployeeHiringChance = c.Int(nullable: false),
                        EquipmentPurchaseChance = c.Int(nullable: false),
                        ResolutionExpenses = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Resolutions");
        }
    }
}
