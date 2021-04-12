using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowroom.Entities.DatabaseModels
{
    public class Maintenance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Client Client { get; set; }

        public Vehicle Vehicle { get; set; }

        public DateTime? MaintainFrom { get; set; }
        
        public DateTime? MaintainUntil { get; set; }

        public double? RepairingHours { get; set; }

        public decimal? TotalCost { get; set; }
    }
}