using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Handlers.Interfaces.Vehicles;

namespace CarShowroom.Handlers.Vehicles
{
    public class CreateVehicleHandler : BaseClientHandler, ICreateVehicleHandler
    {
        public override RequestAction RequestAction => RequestAction.CreateVehicle;

        public DataReciever CreateVehicle(CreateVehicleModel model)
        {
            return SendObject(model);
        }
    }
}