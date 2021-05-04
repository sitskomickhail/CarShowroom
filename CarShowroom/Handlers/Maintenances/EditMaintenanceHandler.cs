using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Maintenances;
using CarShowroom.Handlers.Interfaces.Maintenances;

namespace CarShowroom.Handlers.Maintenances
{
    public class EditMaintenanceHandler : BaseClientHandler, IEditMaintenanceHandler
    {
        public override RequestAction RequestAction => RequestAction.EditMaintenace;

        public DataReciever EditMaintenance(EditMaintenanceModel model)
        {
            return SendObject(model);
        }
    }
}