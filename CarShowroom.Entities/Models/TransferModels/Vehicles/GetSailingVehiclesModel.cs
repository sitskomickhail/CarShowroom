using System;

namespace CarShowroom.Entities.Models.TransferModels.Vehicles
{
    public class GetSailingVehiclesModel
    {
        public string SearchParameter { get; set; } = String.Empty;

        public Guid UserId { get; set; }
    }
}