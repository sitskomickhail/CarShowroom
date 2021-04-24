using System;

namespace CarShowroom.Entities.Models.TransferModels.Vehicles
{
    public class EditVehicleModel
    {
        public Guid Id { get; set; }

        public string Model { get; set; }

        public string Mark { get; set; }

        public bool Salable { get; set; }

        public decimal Cost { get; set; }
    }
}