using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Users;
using CarShowroom.Handlers.Interfaces.Users;

namespace CarShowroom.Handlers.Users
{
    public class GetUserListHandler : BaseClientHandler, IGetUserListHandler
    {
        public override RequestAction RequestAction => RequestAction.GetUsers;

        public DataReciever GetUserList(GetUsersListModel model)
        {
            return SendObject(model);
        }
    }
}