using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Sales;
using CarShowroom.Handlers.Interfaces.Sales;

namespace CarShowroom.Handlers.Sales
{
    public class GetSalesListHandler : BaseClientHandler, IGetSalesListHandler
    {
        public override RequestAction RequestAction => RequestAction.GetSales;

        public DataReciever GetClientList(GetSalesListModel model)
        {
            return SendObject(model);
        }
    }
}