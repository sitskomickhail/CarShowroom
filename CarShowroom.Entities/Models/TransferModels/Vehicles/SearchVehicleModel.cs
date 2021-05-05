using System;

namespace CarShowroom.Entities.Models.TransferModels.Vehicles
{
    public class SearchVehicleModel
    {
        public string SearchParameter { get; set; } = String.Empty;

        public bool SalableOnly { get; set; } = false;
    }
}