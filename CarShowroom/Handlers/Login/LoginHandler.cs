using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels;
using CarShowroom.Handlers.Interfaces.Login;

namespace CarShowroom.Handlers.Login
{
    public class LoginHandler : BaseClientHandler, ILoginHandler
    {
        public override RequestAction RequestAction => RequestAction.Login;

        public DataReciever LoginExecute(LoginModel model)
        {
            return SendObject(model);
        }
    }
}