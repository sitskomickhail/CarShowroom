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
    public class GetClientMaintenancesHandlerService : IHandlerService<GetClientMaintenancesModel, List<MaintenanceAnswerModel>>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<List<MaintenanceAnswerModel>> ExecuteAsync(GetClientMaintenancesModel model)
        {
            var clientMaintenances = await SqlContext.Maintenances.Include(m => m.Client)
                                                                                 .Include(m => m.Client.User)
                                                                                 .Include(m => m.Vehicle)
                                                                                 .Where(m => m.Client.User.Id == model.UserId)
                                                                                 .ToListAsync();

            var maintenancesAnswer = Mapper.Map<List<MaintenanceAnswerModel>>(clientMaintenances);
            return maintenancesAnswer;
        }
    }
}