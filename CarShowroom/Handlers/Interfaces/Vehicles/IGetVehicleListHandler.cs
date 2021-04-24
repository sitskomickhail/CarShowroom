using CarShowroom.Entities.Models.DataTransfers;

namespace CarShowroom.Handlers.Interfaces.Vehicles
{
    public interface IGetVehicleListHandler
    {
        DataReciever GetVehicleList();
    }
}