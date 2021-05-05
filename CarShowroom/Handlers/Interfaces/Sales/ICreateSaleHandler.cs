using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Sales;

namespace CarShowroom.Handlers.Interfaces.Sales
{
    public interface ICreateSaleHandler
    {
        DataReciever CreateSale(CreateSaleModel model);
    }
}