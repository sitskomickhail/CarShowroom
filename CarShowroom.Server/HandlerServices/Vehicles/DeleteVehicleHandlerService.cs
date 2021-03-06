using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Vehicles;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Server.HandlerServices.Interfaces;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Vehicles
{
    public class DeleteVehicleHandlerService : IHandlerService<DeleteVehicleModel, VehicleAnswerModel>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<VehicleAnswerModel> ExecuteAsync(DeleteVehicleModel model)
        {
            var vehicle = await SqlContext.Vehicles.FirstOrDefaultAsync(v => v.Id == model.Id);

            if (vehicle == null)
            {
                throw new Exception("Vehicle doesn't exist in database");
            }

            SqlContext.Vehicles.Remove(vehicle);
            try
            {
                await SqlContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new Exception("This vehicle have stored history of sales or maintenances");
            }

            var answerVehicle = Mapper.Map<VehicleAnswerModel>(vehicle);

            return answerVehicle;
        }
    }
}