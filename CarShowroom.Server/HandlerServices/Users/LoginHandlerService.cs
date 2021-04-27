using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Users;
using CarShowroom.Entities.Models.TransferModels;
using CarShowroom.Server.HandlerServices.Interfaces;
using CarShowroom.Server.Helpers;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Users
{
    public class LoginHandlerService : IHandlerService<LoginModel, UserAnswerModel>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<UserAnswerModel> ExecuteAsync(LoginModel model)
        {
            var user = await SqlContext.Users
                                    .Include(u => u.Role)
                                    .FirstOrDefaultAsync(u => u.Login == model.Login);

            if (user == null)
            {
                throw new InstanceNotFoundException("Login or password in not correct");
            }

            if (user.IsBlocked)
            {
                throw new Exception("Login or password in not correct");
            }

            if (!UserHelper.IsPasswordValid(model.Password, user.PasswordHash, user.Salt))
            {
                throw new InstanceNotFoundException("Login or password in not correct");
            }

            var userAnswer = Mapper.Map<UserAnswerModel>(user);

            return userAnswer;
        }
    }
}