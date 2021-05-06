using System;

namespace CarShowroom.Entities.Models.TransferModels.Maintenances
{
    public class CreateMaintenanceModel
    {
        public Guid UserId { get; set; }

        public Guid VehicleId { get; set; }
    }
}