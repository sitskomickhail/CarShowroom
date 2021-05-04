using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Maintenances;

namespace CarShowroom.Handlers.Interfaces.Maintenances
{
    public interface IEditMaintenanceHandler
    {
        DataReciever EditMaintenance(EditMaintenanceModel model);
    }
}