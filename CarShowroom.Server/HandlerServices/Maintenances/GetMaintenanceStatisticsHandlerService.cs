using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Maintenances;
using CarShowroom.Entities.Models.TransferModels.Maintenances;
using CarShowroom.Server.HandlerServices.Interfaces;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Maintenances
{
    public class GetMaintenanceStatisticsHandlerService : IHandlerService<GetMaintenanceStatisticModel, List<MaintenanceStatisticAnswerModel>>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<List<MaintenanceStatisticAnswerModel>> ExecuteAsync(GetMaintenanceStatisticModel model)
        {
            var clientMaintenances = await SqlContext.Maintenances.Include(m => m.Vehicle)
                                    .Include(m => m.Client)
                                    .Include(m => m.Client.User)
                                    .Where(m => m.Client.User.Id == model.UserId)
                                    .GroupBy(m => m.Vehicle.Mark + " " + m.Vehicle.Model)
                                    .ToListAsync();

            var maintenancesStatistic = new List<MaintenanceStatisticAnswerModel>();
            foreach (var clientMaintenance in clientMaintenances)
            {
                var statistic = new MaintenanceStatisticAnswerModel() { VehicleMark = clientMaintenance.Key };
                foreach (var maintenance in clientMaintenance)
                {
                    statistic.TotalCost += maintenance.TotalCost ?? 0;
                    statistic.TotalHours += maintenance.RepairingHours ?? 0;
                }

                maintenancesStatistic.Add(statistic);
            }

            return maintenancesStatistic;
        }
    }
}