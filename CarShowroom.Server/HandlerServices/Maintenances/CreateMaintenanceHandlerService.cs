using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
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
    public class CreateMaintenanceHandlerService : IHandlerService<CreateMaintenanceModel, MaintenanceAnswerModel>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<MaintenanceAnswerModel> ExecuteAsync(CreateMaintenanceModel model)
        {
            var vehicle = await SqlContext.Vehicles.Include(v => v.Sales).FirstOrDefaultAsync(v => v.Id == model.VehicleId);
            if (vehicle == null)
            {
                throw new Exception("Vehicle was not found");
            }

            var client = await SqlContext.Clients.Include(c => c.User).FirstOrDefaultAsync(c => c.User.Id == model.UserId);
            if(client == null)
            {
                throw new Exception("Client was not found");
            }

            var maintenance = new Maintenance()
            {
                Client = client,
                Vehicle = vehicle,
                MaintainFrom = DateTime.Now
            };

            SqlContext.Maintenances.Add(maintenance);
            await SqlContext.SaveChangesAsync();

            var answer = Mapper.Map<MaintenanceAnswerModel>(maintenance);
            return answer;
        }
    }
}