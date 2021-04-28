using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Clients;

namespace CarShowroom.Handlers.Interfaces.Clients
{
    public interface IGetClientDealInfoHandler
    {
        DataReciever GetClientDeal(GetClientInfoModel model);
    }
}