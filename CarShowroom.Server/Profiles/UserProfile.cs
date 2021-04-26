using AutoMapper;
using CarShowroom.Entities.DatabaseModels;
using CarShowroom.Entities.Models.AnswerModels.Users;
using CarShowroom.Entities.Models.TransferModels.Users;

namespace CarShowroom.Server.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserModel, User>();

            CreateMap<User, UserAnswerModel>().ForMember(ua => ua.Role, 
                opts => opts.MapFrom(u => u.Role.RoleType));
        }
    }
}