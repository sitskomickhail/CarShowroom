using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Maintenances;

namespace CarShowroom.Handlers.Interfaces.Maintenances
{
    public interface IGetMaintenancesHandler
    {
        DataReciever GetMaintenances(GetMaintenanceListModel model);
    }
}