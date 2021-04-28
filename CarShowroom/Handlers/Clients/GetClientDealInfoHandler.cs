using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Clients;
using CarShowroom.Handlers.Interfaces.Clients;

namespace CarShowroom.Handlers.Clients
{
    public class GetClientDealInfoHandler : BaseClientHandler, IGetClientDealInfoHandler
    {
        public override RequestAction RequestAction => RequestAction.GetClientDeals;
        
        public DataReciever GetClientDeal(GetClientInfoModel model)
        {
            return SendObject(model);
        }
    }
}