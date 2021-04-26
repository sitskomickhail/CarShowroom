using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Handlers.Interfaces.Vehicles;

namespace CarShowroom.Handlers.Vehicles
{
    public class SearchVehiclesHandler : BaseClientHandler, ISearchVehiclesHandler
    {
        public override RequestAction RequestAction => RequestAction.SearchVehicles;

        public DataReciever SearchVehicles(SearchVehicleModel model)
        {
            return SendObject(model);
        }
    }
}