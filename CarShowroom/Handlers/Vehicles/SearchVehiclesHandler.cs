using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Handlers.Interfaces.Vehicles;
using CarShowroom.TransferHandlers.Interfaces;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.Handlers.Vehicles
{
    public class SearchVehiclesHandler : ISearchVehiclesHandler
    {
        [Inject]
        public ITcpTransferHandler TcpTransferHandler { get; set; }

        public DataReciever SearchVehicles(SearchVehicleModel model)
        {
            string jsonObject = JsonConvert.SerializeObject(model);
            DataTransfer dataTransfer = new DataTransfer()
            {
                Action = RequestAction.SearchVehicles,
                Object = jsonObject
            };

            string jsonString = JsonConvert.SerializeObject(dataTransfer);
            TcpTransferHandler.WriteStream(jsonString);

            string result = TcpTransferHandler.ReadStream();
            DataReciever dto = JsonConvert.DeserializeObject<DataReciever>(result);

            return dto;
        }
    }
}