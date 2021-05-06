using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Handlers.Interfaces.Vehicles;

namespace CarShowroom.Handlers.Vehicles
{
    public class SearchSailingVehiclesHandler : BaseClientHandler, ISearchSailingVehiclesHandler
    {
        public override RequestAction RequestAction => RequestAction.GetSailingVehicles;
 
        public DataReciever SearchSailingVehicles(GetSailingVehiclesModel model)
        {
            return SendObject(model);
        }
    }
}