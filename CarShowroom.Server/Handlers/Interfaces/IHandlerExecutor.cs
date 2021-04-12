using System.Threading.Tasks;
using CarShowroom.Entities.Models.DataTransfers;

namespace CarShowroom.Server.Handlers.Interfaces
{
    public interface IHandlerExecutor
    {
        Task<string> ExecuteAction(DataTransfer dataTransfer);
    }
}