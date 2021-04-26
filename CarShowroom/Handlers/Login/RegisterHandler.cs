using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels;
using CarShowroom.Handlers.Interfaces.Login;

namespace CarShowroom.Handlers.Login
{
    public class RegisterHandler : BaseClientHandler, IRegisterHandler
    {
        public override RequestAction RequestAction => RequestAction.Register;

        public DataReciever RegisterExecute(RegisterModel model)
        {
            return SendObject(model);
        }
    }
}