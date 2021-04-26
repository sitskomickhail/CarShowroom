using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Vehicles;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Server.HandlerServices.Interfaces;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Vehicles
{
    public class EditVehicleHandlerService : IHandlerService<EditVehicleModel, VehicleAnswerModel>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<VehicleAnswerModel> ExecuteAsync(EditVehicleModel model)
        {
            var vehicle = await SqlContext.Vehicles.FirstOrDefaultAsync(v => v.Id == model.Id);

            if (vehicle == null)
            {
                throw new Exception("Vehicle with such id was not found");
            }

            MapModels(model, vehicle);
            
            await SqlContext.SaveChangesAsync();

            var answerModel = Mapper.Map<VehicleAnswerModel>(vehicle);
            return answerModel;
        }

        private static void MapModels(EditVehicleModel editModel, Vehicle vehicle)
        {
            vehicle.Cost = editModel.Cost;
            vehicle.Mark = editModel.Mark;
            vehicle.Model = editModel.Model;
            vehicle.Salable = editModel.Salable;
        }
    }
}