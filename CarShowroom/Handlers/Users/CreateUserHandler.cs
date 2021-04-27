using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Users;
using CarShowroom.Handlers.Interfaces.Users;

namespace CarShowroom.Handlers.Users
{
    public class CreateUserHandler : BaseClientHandler, ICreateUserHandler
    {
        public override RequestAction RequestAction => RequestAction.CreateUser;

        public DataReciever CreateUser(CreateUserModel model)
        {
            return SendObject(model);
        }
    }
}