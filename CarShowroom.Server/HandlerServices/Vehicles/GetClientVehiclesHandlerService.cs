using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Vehicles;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Server.HandlerServices.Interfaces;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Vehicles
{
    public class GetClientVehiclesHandlerService : IHandlerService<GetClientVehiclesModel, List<VehicleAnswerModel>>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<List<VehicleAnswerModel>> ExecuteAsync(GetClientVehiclesModel model)
        {
            var vehicles = await SqlContext.Vehicles.Include(v => v.Maintenances)
                .Include(v => v.Sales)
                .Include(v => v.Sales.Select(s => s.Client))
                .Include(v => v.Sales.Select(s => s.Client.User))
                .Where(v => v.Sales.Any(s => s.Client.User.Id == model.UserId && s.Status == SaleStatus.Accepted))
                .ToListAsync();

            var vehiclesAnswer = Mapper.Map<List<VehicleAnswerModel>>(vehicles);
            return vehiclesAnswer;
        }
    }
}