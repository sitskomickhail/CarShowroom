using System;
using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
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
            DataTransfer dataTransfer = new DataTransfer()
            {
                Action = RequestAction.GetVehicles,
                Object = String.Empty
            };

            var jsonString = JsonConvert.SerializeObject(dataTransfer);
            TcpTransferHandler.WriteStream(jsonString);

            var result = TcpTransferHandler.ReadStream();
            DataReciever dto = JsonConvert.DeserializeObject<DataReciever>(result);

            return dto;
        }
    }
}