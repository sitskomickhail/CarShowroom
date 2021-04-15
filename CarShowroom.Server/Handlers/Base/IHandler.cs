using System.Threading.Tasks;
using CarShowroom.Entities.Models.DataTransfers;

namespace CarShowroom.Server.Handlers.Base
{
    public interface IHandler
    {
        Task<DataReciever> ExecuteAction(DataTransfer jsonModel);
    }
}