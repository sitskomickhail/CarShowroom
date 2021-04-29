using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Clients;
using CarShowroom.Entities.Models.TransferModels.Clients;
using CarShowroom.Server.HandlerServices.Interfaces;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Clients
{
    public class GetClientDealHandlerService : IHandlerService<GetClientInfoModel, ClientDealsAnswerModel>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<ClientDealsAnswerModel> ExecuteAsync(GetClientInfoModel model)
        {
            var client = await SqlContext.Clients
                           .Include(c => c.User)
                           .Include(c => c.Maintenances).Include(c => c.Maintenances.Select(m => m.Vehicle))
                           .Include(c => c.Sales).Include(c => c.Sales.Select(s => s.Vehicle))
                           .FirstOrDefaultAsync(c => c.Id == model.Id);

            if (client == null)
            {
                throw new Exception("Client was not found");
            }

            var clientDeals = Mapper.Map<ClientDealsAnswerModel>(client);
            return clientDeals;
        }
    }
}