using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowroom.Entities.DatabaseModels
{
    public class Resolution
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int EmployeeHiringChance { get; set; }

        public int EquipmentPurchaseChance { get; set; }

        public int ResolutionExpenses { get; set; }
    }
}