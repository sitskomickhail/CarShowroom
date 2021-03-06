using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Vehicles;

namespace CarShowroom.Handlers.Interfaces.Vehicles
{
    public interface IGetVehicleListHandler
    {
        DataReciever GetVehicleList(GetVehicleListModel model);
    }
}