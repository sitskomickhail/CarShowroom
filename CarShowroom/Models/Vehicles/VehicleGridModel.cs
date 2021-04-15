using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShowroom.Annotations;

namespace CarShowroom.Models.Vehicles
{
    public class VehicleGridModel
    {
        public int Number { get; set; }
        
        [CanBeNull] public string Model { get; set; }

        public string Mark { get; set; }

        public bool Salable { get; set; }

        public decimal Cost { get; set; }

        public bool IsSaled { get; set; }

        public bool IsMaintaining { get; set; }
    }
}
