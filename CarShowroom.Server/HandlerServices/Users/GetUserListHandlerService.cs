using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Users;
using CarShowroom.Entities.Models.TransferModels.Users;
using CarShowroom.Server.HandlerServices.Interfaces;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Users
{
    public class GetUserListHandlerService : IHandlerService<GetUsersListModel, List<UserAnswerModel>>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<List<UserAnswerModel>> ExecuteAsync(GetUsersListModel model)
        {
            var userQuery = SqlContext.Users.Include(u => u.Role);

            if (!model.UserBlocked)
            {
                userQuery = userQuery.Where(u => u.IsBlocked == model.UserBlocked);
            }
            var users = await userQuery.ToListAsync();

            users = users.Select(u => u).Where(u => u.Name.Contains(model.SearchParameter) ||
                                                    u.Login.Contains(model.SearchParameter) ||
                                                    u.Role.RoleType.ToString().Contains(model.SearchParameter)).ToList();

            var userAnswerList = Mapper.Map<List<UserAnswerModel>>(users);

            return userAnswerList;
        }
    }
}