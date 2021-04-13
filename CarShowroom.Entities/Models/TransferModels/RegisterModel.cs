using System;
using CarShowroom.Entities.Models.Enums;

namespace CarShowroom.Entities.Models.TransferModels
{
    [Serializable]
    public class RegisterModel
    {
        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public EnumRoles Role { get; set; }
    }
}