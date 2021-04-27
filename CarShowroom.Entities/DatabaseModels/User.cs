using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowroom.Entities.DatabaseModels
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public bool IsBlocked { get; set; }

        public string Salt { get; set; }

        public Role Role { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}