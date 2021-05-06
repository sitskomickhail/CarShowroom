using System;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Maintenances;
using CarShowroom.Entities.Models.TransferModels.Maintenances;
using CarShowroom.Server.HandlerServices.Interfaces;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Maintenances
{
    public class EditMaintenanceHandlerService : IHandlerService<EditMaintenanceModel, MaintenanceAnswerModel>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }


        public async Task<MaintenanceAnswerModel> ExecuteAsync(EditMaintenanceModel model)
        {
            var maintenance = await SqlContext.Maintenances
                                            .Include(m => m.Client).Include(m => m.Client.User)
                                            .Include(m => m.Client.Maintenances).Include(m => m.Client.Sales)
                                            .Include(m => m.Vehicle)
                                            .FirstOrDefaultAsync(m => m.Id == model.Id);

            MapModels(model, maintenance);
            await SqlContext.SaveChangesAsync();

            var maintenanceAnswer = Mapper.Map<MaintenanceAnswerModel>(maintenance);
            return maintenanceAnswer;
        }

        private static void MapModels(EditMaintenanceModel model, Maintenance maintenance)
        {
            maintenance.TotalCost = model.TotalCost;
            maintenance.MaintainUntil = maintenance.MaintainUntil == null ? 
                DateTime.Now.AddHours(model.RepairingHours) : maintenance.MaintainUntil.Value.AddHours(model.RepairingHours - (double)maintenance.RepairingHours);
            maintenance.RepairingHours = model.RepairingHours;
        }
    }
}