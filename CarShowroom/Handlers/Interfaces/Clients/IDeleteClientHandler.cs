using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Clients;

namespace CarShowroom.Handlers.Interfaces.Clients
{
    public interface IDeleteClientHandler
    {
        DataReciever DeleteClient(DeleteClientModel model);
    }
}