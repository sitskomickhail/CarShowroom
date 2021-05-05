using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Clients;
using CarShowroom.Handlers.Interfaces.Clients;

namespace CarShowroom.Handlers.Clients
{
    public class GetClientByUserIdHandler : BaseClientHandler, IGetClientByUserIdHandler
    {
        public override RequestAction RequestAction => RequestAction.GetClientByUserId;

        public DataReciever GetClient(GetClientByUserIdModel model)
        {
            return SendObject(model);
        }
    }
}