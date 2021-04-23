using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Handlers.Interfaces.Vehicles;
using CarShowroom.TransferHandlers.Interfaces;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.Handlers.Vehicles
{
    public class EditVehicleHandler : IEditVehicleHandler
    {
        [Inject]
        public ITcpTransferHandler TcpTransferHandler { get; set; }

        public DataReciever EditVehicle(EditVehicleModel model)
        {
            string jsonObject = JsonConvert.SerializeObject(model);
            DataTransfer transfer = new DataTransfer()
            {
                Action = RequestAction.EditVehicle,
                Object = jsonObject
            };

            string jsonString = JsonConvert.SerializeObject(transfer);
            TcpTransferHandler.WriteStream(jsonString);

            var result = TcpTransferHandler.ReadStream();
            DataReciever dto = JsonConvert.DeserializeObject<DataReciever>(result);

            return dto;
        }
    }
}