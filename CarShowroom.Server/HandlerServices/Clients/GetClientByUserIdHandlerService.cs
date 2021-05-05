using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Clients;
using CarShowroom.Entities.Models.TransferModels.Clients;
using CarShowroom.Server.HandlerServices.Interfaces;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Clients
{
    public class GetClientByUserIdHandlerService : IHandlerService<GetClientByUserIdModel, ClientAnswerModel>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<ClientAnswerModel> ExecuteAsync(GetClientByUserIdModel model)
        {
            var client = await SqlContext.Clients.Include(c => c.User)
                                                         .Include(c => c.Maintenances)
                                                         .Include(c => c.Sales).FirstOrDefaultAsync(c => c.User.Id == model.Id);

            var clientAnswer = Mapper.Map<ClientAnswerModel>(client);
            return clientAnswer;
        }
    }
}