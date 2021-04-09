using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Entities.DatabaseModels
{
    public class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public string? Model { get; set; }
        
        public string? Mark { get; set; }

        public bool? Salable { get; set; }

        public int? Capacity { get; set; }
        
        public decimal? Cost { get; set; }
    }
}