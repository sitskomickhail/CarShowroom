using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Users;

namespace CarShowroom.Handlers.Interfaces.Users
{
    public interface IGetUserListHandler
    {
        DataReciever GetUserList(GetUsersListModel model);
    }
}