using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Sales;
using CarShowroom.Handlers.Interfaces.Sales;

namespace CarShowroom.Handlers.Sales
{
    public class AcceptSaleHandler : BaseClientHandler, IAcceptSaleHandler
    {
        public override RequestAction RequestAction => RequestAction.AcceptSale;
        
        public DataReciever ChangeSaleStatus(AcceptSaleModel model)
        {
            return SendObject(model);
        }
    }
}