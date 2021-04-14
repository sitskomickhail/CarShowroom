using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels;
using CarShowroom.Handlers.Interfaces.Login;
using CarShowroom.TransferHandlers.Interfaces;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.Handlers.Login
{
    public class LoginHandler : ILoginHandler
    {
        [Inject]
        public ITcpTransferHandler TcpTransferHandler { get; set; }

        public DataReciever LoginExecute(LoginModel model)
        {
            TcpTransferHandler.WriteStream($"{model.Login} + {model.Password}");

            var result = TcpTransferHandler.ReadStream();
            DataReciever dto = JsonConvert.DeserializeObject<DataReciever>(result);
            
            return dto;
        }
    }
}