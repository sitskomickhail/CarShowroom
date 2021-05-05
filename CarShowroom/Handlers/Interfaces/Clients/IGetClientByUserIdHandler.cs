using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Clients;

namespace CarShowroom.Handlers.Interfaces.Clients
{
    public interface IGetClientByUserIdHandler
    {
        DataReciever GetClient(GetClientByUserIdModel model);
    }
}