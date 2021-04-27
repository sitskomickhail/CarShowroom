using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Users;
using CarShowroom.Entities.Models.TransferModels.Users;
using CarShowroom.Server.HandlerServices.Interfaces;
using CarShowroom.Server.Helpers;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Users
{
    public class CreateUserHandlerService : IHandlerService<CreateUserModel, UserAnswerModel>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<UserAnswerModel> ExecuteAsync(CreateUserModel model)
        {
            var existingUser = await SqlContext.Users.FirstOrDefaultAsync(u => u.Login == model.Login);

            if (existingUser != null)
            {
                throw new DuplicateNameException("The user with such login already exists");
            }

            var role = await SqlContext.Roles.FirstOrDefaultAsync(r => r.RoleType == model.Role) ?? new Role()
            {
                RoleType = model.Role
            };

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