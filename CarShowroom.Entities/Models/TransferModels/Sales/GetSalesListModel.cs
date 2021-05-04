using System;

namespace CarShowroom.Entities.Models.TransferModels.Sales
{
    public class GetSalesListModel
    {
        public string SearchParameter { get; set; } = String.Empty;

        public bool AcceptedSale { get; set; }
    }
}