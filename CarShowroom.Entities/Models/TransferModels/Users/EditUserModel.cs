using System;
using CarShowroom.Entities.Models.Enums;

namespace CarShowroom.Entities.Models.TransferModels.Users
{
    public class EditUserModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public EnumRoles Role { get; set; }
    }
}