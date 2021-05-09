using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowroom.Entities.DatabaseModels
{
    public class Resolution
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int EmployeeSuccess_EquipmentSuccessChance { get; set; }

        public int EmployeeSuccess_EquipmentFailChance { get; set; }

        public int EmployeeFail_EquipmentSuccessChance { get; set; }

        public int EmployeeFail_EquipmentFailChance { get; set; }

        public int ResolutionExpenses { get; set; }
    }
}