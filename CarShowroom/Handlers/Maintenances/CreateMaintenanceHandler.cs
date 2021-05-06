using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Maintenances;
using CarShowroom.Handlers.Interfaces.Maintenances;

namespace CarShowroom.Handlers.Maintenances
{
    public class CreateMaintenanceHandler : BaseClientHandler, ICreateMaintenanceHandler
    {
        public override RequestAction RequestAction => RequestAction.CreateMaintenance;

        public DataReciever CreateMaintenance(CreateMaintenanceModel model)
        {
            return SendObject(model);
        }
    }
}