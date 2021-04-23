using System;

namespace CarShowroom.Entities.Models.AnswerModels.Vehicles
{
    public class VehicleAnswerModel
    {
        public Guid Id { get; set; }

        public string Model { get; set; }

        public string Mark { get; set; }

        public bool Salable { get; set; }

        public decimal Cost { get; set; }

        public bool IsSaled { get; set; }

        public bool IsMaintaining { get; set; }
    }
}