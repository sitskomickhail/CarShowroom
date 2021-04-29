using System;
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
    public class DeleteClientHandlerService : IHandlerService<DeleteClientModel, ClientAnswerModel>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<ClientAnswerModel> ExecuteAsync(DeleteClientModel model)
        {
            var client = await SqlContext.Clients.Include(c => c.User)
                                                 .Include(c => c.Maintenances)
                                                 .Include(c => c.Sales)
                                                 .FirstOrDefaultAsync(c => c.Id == model.Id);

            if (client == null)
            {
                throw new Exception("Client was not found");
            }

            client.User.IsBlocked = true;
            await SqlContext.SaveChangesAsync();

            var clientAnswer = Mapper.Map<ClientAnswerModel>(client);
            return clientAnswer;
        }
    }
}