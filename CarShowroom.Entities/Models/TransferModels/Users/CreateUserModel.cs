using CarShowroom.Entities.Models.Enums;

namespace CarShowroom.Entities.Models.TransferModels.Users
{
    public class CreateUserModel
    {
        public string Name { get; set; }

        public EnumRoles Role { get; set; } = EnumRoles.Employee;

        public string Login { get; set; }

        public string Password { get; set; }
    }
}