using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Handlers.Interfaces.Vehicles;
using CarShowroom.TransferHandlers.Interfaces;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.Handlers.Vehicles
{
    public class CreateVehicleHandler : ICreateVehicleHandler
    {
        [Inject]
        public ITcpTransferHandler TcpTransferHandler { get; set; }

        public DataReciever CreateVehicle(CreateVehicleModel model)
        {
            var jsonObject = JsonConvert.SerializeObject(model);
            DataTransfer dataTransfer = new DataTransfer()
            {
                Action = RequestAction.CreateVehicle,
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