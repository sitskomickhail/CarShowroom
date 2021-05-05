using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Sales;
using CarShowroom.Handlers.Interfaces.Sales;

namespace CarShowroom.Handlers.Sales
{
    public class CreateSaleHandler : BaseClientHandler, ICreateSaleHandler
    {
        public override RequestAction RequestAction => RequestAction.CreateSale;

        public DataReciever CreateSale(CreateSaleModel model)
        {
            return SendObject(model);
        }
    }
}