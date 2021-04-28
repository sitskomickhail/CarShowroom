using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Clients;

namespace CarShowroom.Handlers.Interfaces.Clients
{
    public interface IGetClientListHandler
    {
        DataReciever GetClientList(GetClientListModel model);
    }
}