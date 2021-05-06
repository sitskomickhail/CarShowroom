using System;

namespace CarShowroom.Entities.Models.TransferModels.Maintenances
{
    public class EditMaintenanceModel
    {
        public Guid Id { get; set; }

        public double RepairingHours { get; set; }

        public decimal TotalCost { get; set; }
    }
}