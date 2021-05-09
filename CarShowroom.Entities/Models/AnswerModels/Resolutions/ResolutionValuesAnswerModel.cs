namespace CarShowroom.Entities.Models.AnswerModels.Resolutions
{
    public class ResolutionValuesAnswerModel
    {
        public int EmployeeSuccess_EquipmentSuccessChance { get; set; }

        public int EmployeeSuccess_EquipmentFailChance { get; set; }

        public int EmployeeFail_EquipmentSuccessChance { get; set; }

        public int EmployeeFail_EquipmentFailChance { get; set; }  

        public int ResolutionExpenses { get; set; }
    }
}