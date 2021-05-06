using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowroom.Entities.DatabaseModels
{
    public class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public string? Model { get; set; }
        
        public string? Mark { get; set; }

        public bool? Salable { get; set; }
        
        public decimal? Cost { get; set; }

        public List<Sale>? Sales { get; set; }

        public List<Maintenance>? Maintenances { get; set; }
    }
}