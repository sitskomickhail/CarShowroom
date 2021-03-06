using System;
using CarShowroom.Entities.Models.Enums;

namespace CarShowroom.Entities.Models.AnswerModels.Users
{
    [Serializable]
    public class UserAnswerModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public bool IsBlocked { get; set; }

        public EnumRoles Role { get; set; }
    }
}