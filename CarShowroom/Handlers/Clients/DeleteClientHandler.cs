using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Clients;
using CarShowroom.Handlers.Interfaces.Clients;

namespace CarShowroom.Handlers.Clients
{
    public class DeleteClientHandler : BaseClientHandler, IDeleteClientHandler
    {
        public override RequestAction RequestAction => RequestAction.DeleteClient;

        public DataReciever DeleteClient(DeleteClientModel model)
        {
            return SendObject(model);
        }
    }
}