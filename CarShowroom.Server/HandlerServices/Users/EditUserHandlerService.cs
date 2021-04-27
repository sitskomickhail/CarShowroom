using System;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Users;
using CarShowroom.Entities.Models.TransferModels.Users;
using CarShowroom.Server.HandlerServices.Interfaces;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Users
{
    public class EditUserHandlerService : IHandlerService<EditUserModel, UserAnswerModel>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<UserAnswerModel> ExecuteAsync(EditUserModel model)
        {
            var user = await SqlContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == model.Id);

            if (user == null)
            {
                throw new Exception("User with such id doesn't exists");
            }

            MapModels(model, user);

            await SqlContext.SaveChangesAsync();

            var userAnswer = Mapper.Map<UserAnswerModel>(user);
            return userAnswer;
        }

        private static void MapModels(EditUserModel editModel, User user)
        {
            user.Name = editModel.Name;
        }
    }
}