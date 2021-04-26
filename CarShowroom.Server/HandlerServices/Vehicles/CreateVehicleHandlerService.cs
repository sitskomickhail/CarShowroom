using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Task<VehicleAnswerModel> ExecuteAsync(CreateVehicleModel model)
        {
            throw new NotImplementedException();
        }
    }
}