using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Vehicles;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Server.HandlerServices.Interfaces;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Vehicles
{
    public class SearchVehiclesHandlerService : IHandlerService<SearchVehicleModel, List<VehicleAnswerModel>>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<List<VehicleAnswerModel>> ExecuteAsync(SearchVehicleModel model)
        {
            var vehiclesList = await SqlContext.Vehicles.Include(v => v.Maintenance).Include(v => v.Sale).ToListAsync();

            vehiclesList = vehiclesList.Select(v => v).Where(v => v.Model.Contains(model.SearchParameter) ||
                                                                  v.Mark.Contains(model.SearchParameter) ||
                                                                  v.Cost.ToString().Contains(model.SearchParameter)).ToList();

            var answerList = Mapper.Map<List<VehicleAnswerModel>>(vehiclesList);

            return answerList;
        }
    }
}