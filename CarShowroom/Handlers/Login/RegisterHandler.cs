using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels;
using CarShowroom.Handlers.Interfaces.Login;
using CarShowroom.TransferHandlers.Interfaces;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.Handlers.Login
{
    public class RegisterHandler : IRegisterHandler
    {
        [Inject]
        public ITcpTransferHandler TcpTransferHandler { get; set; }

        public DataReciever RegisterExecute(RegisterModel model)
        {
            TcpTransferHandler.WriteStream($"{model.Login} + {model.Password} + {model.Role.ToString()}");

            var result = TcpTransferHandler.ReadStream();
            DataReciever dto = JsonConvert.DeserializeObject<DataReciever>(result);

            return dto;
        }
    }
}