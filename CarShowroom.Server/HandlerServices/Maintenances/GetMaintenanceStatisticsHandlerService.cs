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
                                    .ToListAsync();

            return new List<MaintenanceStatisticAnswerModel>();
        }
    }
}