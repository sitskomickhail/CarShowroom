using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Maintenances;
using CarShowroom.Handlers.Interfaces.Maintenances;

namespace CarShowroom.Handlers.Maintenances
{
    public class GetClientMaintenancesHandler : BaseClientHandler, IGetClientMaintenancesHandler
    {
        public override RequestAction RequestAction => RequestAction.GetClientMaintenances;

        public DataReciever GetClientMaintenances(GetClientMaintenancesModel model)
        {
            return SendObject(model);
        }
    }
}