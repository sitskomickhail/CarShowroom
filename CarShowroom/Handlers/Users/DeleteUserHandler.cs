using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Users;
using CarShowroom.Handlers.Interfaces.Users;

namespace CarShowroom.Handlers.Users
{
    public class DeleteUserHandler : BaseClientHandler, IDeleteUserHandler
    {
        public override RequestAction RequestAction => RequestAction.DeleteUser;

        public DataReciever DeleteUser(DeleteUserModel model)
        {
            return SendObject(model);
        }
    }
}