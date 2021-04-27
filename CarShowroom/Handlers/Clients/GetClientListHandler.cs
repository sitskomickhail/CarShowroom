using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Clients;
using CarShowroom.Handlers.Interfaces.Clients;

namespace CarShowroom.Handlers.Clients
{
    public class GetClientListHandler : BaseClientHandler, IGetClientListHandler
    {
        public override RequestAction RequestAction => RequestAction.GetClients;

        public DataReciever GetClientList(GetClientListModel model)
        {
            return SendObject(model);
        }
    }
}