using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Clients;
using CarShowroom.Handlers.Interfaces.Clients;

namespace CarShowroom.Handlers.Clients
{
    public class EditClientHandler : BaseClientHandler, IEditClientHandler
    {
        public override RequestAction RequestAction => RequestAction.EditClient;
        
        public DataReciever EditClient(EditClientModel model)
        {
            return SendObject(model);
        }
    }
}