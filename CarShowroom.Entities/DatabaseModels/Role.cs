using System;
using System.ComponentModel.DataAnnotations.Schema;
using CarShowroom.Entities.Models.Enums;

namespace CarShowroom.Entities.DatabaseModels
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public EnumRoles RoleType { get; set; }
    }
}