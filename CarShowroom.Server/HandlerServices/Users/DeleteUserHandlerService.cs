using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Users;
using CarShowroom.Entities.Models.TransferModels.Users;
using CarShowroom.Server.HandlerServices.Interfaces;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Users
{
    public class DeleteUserHandlerService : IHandlerService<DeleteUserModel, UserAnswerModel>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<UserAnswerModel> ExecuteAsync(DeleteUserModel model)
        {
            var user = await SqlContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == model.Id);

            user.IsBlocked = true;
            await SqlContext.SaveChangesAsync();

            var userAnswer = Mapper.Map<UserAnswerModel>(user);
            return userAnswer;
        }
    }
}