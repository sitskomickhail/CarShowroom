using System;
using CarShowroom.Entities.Models.Enums;

namespace CarShowroom.Models.Sales
{
    public class SaleGridModel
    {
        public Guid Id { get; set; }

        public int Position { get; set; }

        public string Client { get; set; }

        public string Vehicle { get; set; }

        public DateTime SaleTime { get; set; }

        public decimal TotalCost { get; set; }

        public string PaymentMethod { get; set; }

        public DateTime PaymentAbove { get; set; }

        public string Status { get; set; }
    }
}