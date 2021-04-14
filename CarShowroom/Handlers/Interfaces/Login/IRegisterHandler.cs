using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels;

namespace CarShowroom.Handlers.Interfaces.Login
{
    public interface IRegisterHandler
    {
        DataReciever RegisterExecute(RegisterModel model);
    }
}