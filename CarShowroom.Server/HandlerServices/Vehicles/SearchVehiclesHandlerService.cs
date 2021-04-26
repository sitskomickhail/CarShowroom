using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShowroom.Entities.Models.AnswerModels.Vehicles;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Server.HandlerServices.Interfaces;

namespace CarShowroom.Server.HandlerServices.Vehicles
{
    public class SearchVehiclesHandlerService : IHandlerService<SearchVehicleModel, List<VehicleAnswerModel>>
    {
        public Task<List<VehicleAnswerModel>> ExecuteAsync(SearchVehicleModel model)
        {
            throw new NotImplementedException();
        }
    }
}
