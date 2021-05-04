using System;

namespace CarShowroom.Entities.Models.TransferModels.Sales
{
    public class AcceptSaleModel
    {
        public Guid Id { get; set; }

        public bool IsAccepted { get; set; }
    }
}