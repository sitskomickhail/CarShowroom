using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowroom.Entities.DatabaseModels
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string? Address { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Number { get; set; }

        public User User { get; set; }

        public ICollection<Sale> Sales { get; set; }

        public ICollection<Maintenance> Maintenances { get; set; }
    }
}