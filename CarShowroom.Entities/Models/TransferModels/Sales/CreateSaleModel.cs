using System;
using System.Collections.Generic;

namespace CarShowroom.Entities.Models.TransferModels.Sales
{
    public class CreateSaleModel
    {
        public Guid UserId { get; set; }

        public List<Guid> Vehicles { get; set; }

        public string PaymentMethod { get; set; }
    }
}