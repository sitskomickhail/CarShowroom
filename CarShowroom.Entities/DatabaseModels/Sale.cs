using System;
using System.ComponentModel.DataAnnotations.Schema;
using CarShowroom.Entities.Models.Enums;

namespace CarShowroom.Entities.DatabaseModels
{
    public class Sale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public Client Client { get; set; }

        public Vehicle Vehicle { get; set; }
        
        public DateTime? SaleTime { get; set; }
        
        public decimal? TotalCost { get; set; }
        
        public string? PaymentMethod { get; set; }

        public DateTime? PaymentAbove { get; set; }

        public SaleStatus? Status { get; set; }
    }
}