using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.TransferHandlers.Interfaces;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.Handlers
{
    public abstract class BaseClientHandler
    {
        [Inject]
        public ITcpTransferHandler TcpTransferHandler { get; set; }

        public abstract RequestAction RequestAction { get; }

        protected virtual DataReciever SendObject<T>(T model)
        {
            var jsonObject = JsonConvert.SerializeObject(model);
            DataTransfer dataTransfer = new DataTransfer()
            {
                Action = RequestAction,
                Object = jsonObject
            };

            var jsonString = JsonConvert.SerializeObject(dataTransfer);
            TcpTransferHandler.WriteStream(jsonString);

            var result = TcpTransferHandler.ReadStream();
            DataReciever dto = JsonConvert.DeserializeObject<DataReciever>(result);

            return dto;
        }
    }
}