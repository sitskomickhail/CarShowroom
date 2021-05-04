using System;
using CarShowroom.Entities.Models.AnswerModels.Clients;
using CarShowroom.Entities.Models.AnswerModels.Vehicles;
using CarShowroom.Entities.Models.Enums;

namespace CarShowroom.Entities.Models.AnswerModels.Sales
{
    public class SaleAnswerModel
    {
        public Guid Id { get; set; }

        public ClientAnswerModel Client { get; set; }

        public VehicleAnswerModel Vehicle { get; set; }

        public DateTime SaleTime { get; set; }

        public decimal TotalCost { get; set; }

        public string PaymentMethod { get; set; }

        public DateTime PaymentAbove { get; set; }

        public SaleStatus Status { get; set; }
    }
}