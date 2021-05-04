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
    public class GetMaintenanceListHandlerService : IHandlerService<GetMaintenanceListModel, List<MaintenanceAnswerModel>>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<List<MaintenanceAnswerModel>> ExecuteAsync(GetMaintenanceListModel model)
        {
            var maintenances = await SqlContext.Maintenances
                                        .Include(m => m.Client).Include(m => m.Client.User)
                                        .Include(m => m.Client.Maintenances).Include(m => m.Client.Sales)
                                        .Include(m => m.Vehicle).ToListAsync();

            maintenances = maintenances.Select(m => m).Where(m => m.Client.User.Name.Contains(model.SearchParameter) || 
                                                                                     m.TotalCost.ToString().Contains(model.SearchParameter) ||
                                                                                     m.RepairingHours.ToString().Contains(model.SearchParameter) ||
                                                                                     m.Vehicle.Model.Contains(model.SearchParameter) || 
                                                                                     m.Vehicle.Mark.Contains(model.SearchParameter)).ToList();

            var answerList = Mapper.Map<List<MaintenanceAnswerModel>>(maintenances);
            return answerList;
        }
    }
}