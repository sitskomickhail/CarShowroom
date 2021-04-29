using System.Collections.Generic;
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
    public class GetClientListHandlerService : IHandlerService<GetClientListModel, List<ClientAnswerModel>>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<List<ClientAnswerModel>> ExecuteAsync(GetClientListModel model)
        {
            var clients = await SqlContext.Clients
                .Include(c => c.User)
                .Include(c => c.Maintenances)
                .Include(c => c.Sales).Where(c => c.User.IsBlocked == false).ToListAsync();

            clients = clients.Select(s => s).Where(s => s.User.Name.Contains(model.SearchParameter) ||
                                                        s.Number.Contains(model.SearchParameter) ||
                                                        s.Email.Contains(model.SearchParameter) ||
                                                        s.Address.Contains(model.SearchParameter)).ToList();

            var clientsList = Mapper.Map<List<ClientAnswerModel>>(clients);
            return clientsList;
        }
    }
}