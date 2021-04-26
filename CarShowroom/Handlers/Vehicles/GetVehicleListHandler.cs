using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Handlers.Interfaces.Vehicles;
using CarShowroom.TransferHandlers.Interfaces;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.Handlers.Vehicles
{
    public class GetVehicleListHandler : IGetVehicleListHandler
    {
        [Inject]
        public ITcpTransferHandler TcpTransferHandler { get; set; }

        public DataReciever GetVehicleList()
        {
            GetVehicleListModel model = new GetVehicleListModel();
            string jsonObject = JsonConvert.SerializeObject(model);

            DataTransfer dataTransfer = new DataTransfer()
            {
                Action = RequestAction.GetVehicles,
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