using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Vehicles;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Server.HandlerServices.Interfaces;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Vehicles
{
    public class GetVehiclesHandlerService : IHandlerService<GetVehicleListModel, List<VehicleAnswerModel>>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<List<VehicleAnswerModel>> ExecuteAsync(GetVehicleListModel model)
        {
            var vehicleList = await SqlContext.Vehicles.ToListAsync();

            var answerList = Mapper.Map<List<VehicleAnswerModel>>(vehicleList);

            return answerList;
        }
    }
}