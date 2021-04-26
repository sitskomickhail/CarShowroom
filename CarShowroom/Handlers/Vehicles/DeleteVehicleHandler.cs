using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Handlers.Interfaces.Vehicles;

namespace CarShowroom.Handlers.Vehicles
{
    public class DeleteVehicleHandler : BaseClientHandler, IDeleteVehicleHandler
    {
        public override RequestAction RequestAction => RequestAction.DeleteVehicle;

        public DataReciever DeleteVehicle(DeleteVehicleModel model)
        {
            return SendObject(model);
        }
    }
}