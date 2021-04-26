using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Handlers.Interfaces.Vehicles;

namespace CarShowroom.Handlers.Vehicles
{
    public class EditVehicleHandler : BaseClientHandler, IEditVehicleHandler
    {
        public override RequestAction RequestAction => RequestAction.EditVehicle;

        public DataReciever EditVehicle(EditVehicleModel model)
        {
            return SendObject(model);
        }
    }
}