using System;
using CarShowroom.Entities.Models.AnswerModels.Clients;
using CarShowroom.Entities.Models.AnswerModels.Vehicles;

namespace CarShowroom.Entities.Models.AnswerModels.Maintenances
{
    public class MaintenanceAnswerModel
    {
        public Guid Id { get; set; }

        public ClientAnswerModel Client { get; set; }

        public VehicleAnswerModel Vehicle { get; set; }

        public DateTime MaintainFrom { get; set; }

        public DateTime MaintainUntil { get; set; }

        public double RepairingHours { get; set; }

        public decimal TotalCost { get; set; }
    }
}