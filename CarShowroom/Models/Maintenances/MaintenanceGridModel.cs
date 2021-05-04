using System;

namespace CarShowroom.Models.Maintenances
{
    public class MaintenanceGridModel
    {
        public Guid Id { get; set; }

        public int Position { get; set; }

        public string Client { get; set; }

        public string Vehicle { get; set; }

        public DateTime MaintainFrom { get; set; }

        public DateTime MaintainUntil { get; set; }

        public double RepairingHours { get; set; }

        public decimal TotalCost { get; set; }
    }
}