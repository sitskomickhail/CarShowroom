using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Maintenances;
using CarShowroom.Handlers.Interfaces.Maintenances;

namespace CarShowroom.Handlers.Maintenances
{
    public class GetMaintenanceStatisticsHandler : BaseClientHandler, IGetMaintenanceStatisticsHandler
    {
        public override RequestAction RequestAction => RequestAction.GetMaintenanceStatistic;

        public DataReciever GetMaintenanceStatistics(GetMaintenanceStatisticModel model)
        {
            return SendObject(model);
        }
    }
}