using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Users;

namespace CarShowroom.Handlers.Interfaces.Users
{
    public interface IEditUserHandler
    {
        DataReciever SaveUser(EditUserModel model);
    }
}