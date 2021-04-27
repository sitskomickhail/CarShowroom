using AutoMapper;
using CarShowroom.Entities.Models.AnswerModels.Users;
using CarShowroom.Entities.Models.TransferModels.Users;
using CarShowroom.Models.Users;

namespace CarShowroom.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAnswerModel, UserGridModel>().ForMember(ug => ug.Role, opts => opts.MapFrom(ua => ua.Role.ToString()));
            CreateMap<UserGridModel, DeleteUserModel>();
            CreateMap<UserGridModel, EditUserModel>();
        }
    }
}