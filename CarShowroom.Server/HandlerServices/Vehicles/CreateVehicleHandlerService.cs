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
    public class CreateVehicleHandlerService : IHandlerService<CreateVehicleModel, VehicleAnswerModel>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<VehicleAnswerModel> ExecuteAsync(CreateVehicleModel model)
        {
            Vehicle vehicle = Mapper.Map<Vehicle>(model);

            SqlContext.Vehicles.Add(vehicle);
            await SqlContext.SaveChangesAsync();

            var vehicleAnswer = Mapper.Map<VehicleAnswerModel>(vehicle);

            return vehicleAnswer;
        }
    }
}