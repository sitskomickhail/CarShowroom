using System.Threading.Tasks;
using CarShowroom.Entities.Models.DataTransfers;

namespace CarShowroom.Server.Handlers.Interfaces
{
    public interface IHandlerExecutor
    {
        Task<DataReciever> ExecuteAction(DataTransfer dataTransfer);
    }
}