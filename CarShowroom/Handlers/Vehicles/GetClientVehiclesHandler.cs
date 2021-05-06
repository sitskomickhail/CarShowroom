using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Handlers.Interfaces.Vehicles;

namespace CarShowroom.Handlers.Vehicles
{
    public class GetClientVehiclesHandler : BaseClientHandler, IGetClientVehiclesHandler
    {
        public override RequestAction RequestAction => RequestAction.GetClientVehicles;

        public DataReciever GetClientVehicles(GetClientVehiclesModel model)
        {
            return SendObject(model);
        }
    }
}