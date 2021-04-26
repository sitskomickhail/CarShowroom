using System;
using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Users;
using CarShowroom.Handlers.Interfaces.Users;

namespace CarShowroom.Handlers.Users
{
    public class EditUserHandler : BaseClientHandler, IEditUserHandler
    {
        public override RequestAction RequestAction => RequestAction.EditUser;

        public DataReciever SaveUser(EditUserModel model)
        {
            return SendObject(model);
        }
    }
}