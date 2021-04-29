using System;

namespace CarShowroom.Models.Sales
{
    public class SaleGridModel
    {
        public Guid Id { get; set; }

        public string Position { get; set; }

        public string Client { get; set; }

        public string Vehicle { get; set; }

        public DateTime SaleTime { get; set; }

        public decimal TotalCost { get; set; }

        public string PaymentMethod { get; set; }

        public DateTime PaymentAbove { get; set; }
    }
}