using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Users;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels;
using CarShowroom.Server.HandlerServices.Interfaces;
using CarShowroom.Server.Helpers;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Users
{
    public class RegistrateHandlerService : IHandlerService<RegisterModel, UserAnswerModel>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        private readonly string _administratorSecretPassword = "cbybq hs,fr";

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<UserAnswerModel> ExecuteAsync(RegisterModel model)
        {
            if (model.Role == EnumRoles.Administrator)
            {
                if (!model.SecretPassword.Equals(_administratorSecretPassword, StringComparison.Ordinal))
                {
                    throw new InvalidCredentialException("Administartor secret password is invalid");
                }
            }

            var existingUser = await SqlContext.Users.FirstOrDefaultAsync(u => u.Login == model.Login);

            if (existingUser != null)
            {
                throw new DuplicateNameException("The user with such login already exists");
            }

            var role = await SqlContext.Roles.FirstOrDefaultAsync(r => r.RoleType == model.Role);
            if (role == null)
            {
                role = new Role()
                {
                    RoleType = model.Role
                };
            }

            var hashSalt = UserHelper.GenerateSalt();
            var hashPassword = UserHelper.GenerateHash(model.Password, hashSalt);

            var user = new User()
            {
                Login = model.Login,
                Name = model.Name,
                Role = role,
                Salt = hashSalt,
                PasswordHash = hashPassword
            };

            SqlContext.Users.Add(user);

            await SqlContext.SaveChangesAsync();

            var answer = Mapper.Map<UserAnswerModel>(user);

            return answer;
        }
    }
}