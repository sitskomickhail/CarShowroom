using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
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
            var jsonModel = JsonConvert.SerializeObject(model);
            DataTransfer dataTransfer = new DataTransfer()
            {
                Action = RequestAction.Register,
                Object = jsonModel
            };

            var jsonString = JsonConvert.SerializeObject(dataTransfer);
            TcpTransferHandler.WriteStream(jsonString);

            var result = TcpTransferHandler.ReadStream();
            DataReciever dto = JsonConvert.DeserializeObject<DataReciever>(result);

            return dto;
        }
    }
}