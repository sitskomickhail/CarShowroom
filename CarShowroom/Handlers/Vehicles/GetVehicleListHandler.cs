using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Handlers.Interfaces.Vehicles;

namespace CarShowroom.Handlers.Vehicles
{
    public class GetVehicleListHandler : BaseClientHandler, IGetVehicleListHandler
    {
        public override RequestAction RequestAction => RequestAction.GetVehicles;

        public DataReciever GetVehicleList(GetVehicleListModel model)
        {
            return SendObject(model);
        }
    }
}