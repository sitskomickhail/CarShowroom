using System;
using CarShowroom.Annotations;

namespace CarShowroom.Models.Vehicles
{
    public class VehicleGridModel
    {
        public Guid Id { get; set; }

        public int Number { get; set; }
        
        [CanBeNull] public string Model { get; set; }

        public string Mark { get; set; }

        public bool Salable { get; set; }

        public decimal Cost { get; set; }

        public bool IsSaled { get; set; }

        public bool IsMaintaining { get; set; }

        public bool IsChanged { get; set; } = false;
    }
}