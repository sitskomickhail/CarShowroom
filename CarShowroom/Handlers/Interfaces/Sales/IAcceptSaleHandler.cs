using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Sales;

namespace CarShowroom.Handlers.Interfaces.Sales
{
    public interface IAcceptSaleHandler
    {
        DataReciever ChangeSaleStatus(AcceptSaleModel model);
    }
}