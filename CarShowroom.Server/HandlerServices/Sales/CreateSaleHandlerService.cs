using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Sales;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Sales;
using CarShowroom.Server.HandlerServices.Interfaces;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Sales
{
    public class CreateSaleHandlerService : IHandlerService<CreateSaleModel, List<SaleAnswerModel>>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<List<SaleAnswerModel>> ExecuteAsync(CreateSaleModel model)
        {
            var client = await SqlContext.Clients.Include(c => c.User)
                                                 .Include(c => c.Maintenances)
                                                 .FirstOrDefaultAsync(c => c.User.Id == model.UserId);

            if (client == null)
            {
                throw new Exception("Current client was not found");
            }

            List<Sale> salesList = new List<Sale>();
            foreach (var vehicleId in model.Vehicles)
            {
                var vehicle = await SqlContext.Vehicles.Include(c => c.Maintenances).FirstOrDefaultAsync(v => v.Id == vehicleId);

                salesList.Add(new Sale()
                {
                    Client = client,
                    Status = SaleStatus.Waiting,
                    Vehicle = vehicle,
                    PaymentMethod = model.PaymentMethod,
                    TotalCost = vehicle.Cost
                });
            }

            SqlContext.Sales.AddRange(salesList);
            await SqlContext.SaveChangesAsync();

            var answerModel = Mapper.Map<List<SaleAnswerModel>>(salesList);
            return answerModel;
        }
    }
}