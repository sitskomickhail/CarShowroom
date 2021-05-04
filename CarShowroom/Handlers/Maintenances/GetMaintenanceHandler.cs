using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Maintenances;
using CarShowroom.Handlers.Interfaces.Maintenances;

namespace CarShowroom.Handlers.Maintenances
{
    class GetMaintenancesHandler : BaseClientHandler, IGetMaintenancesHandler
    {
        public override RequestAction RequestAction => RequestAction.GetMaintenances;

        public DataReciever GetMaintenances(GetMaintenanceListModel model)
        {
            return SendObject(model);
        }
    }
}