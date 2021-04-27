using AutoMapper;
using CarShowroom.Entities.Models.AnswerModels.Clients;
using CarShowroom.Entities.Models.TransferModels.Clients;
using CarShowroom.Models.Clients;

namespace CarShowroom.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientAnswerModel, ClientGridModel>().ForMember(cg => cg.PhoneNumber, opts => opts.MapFrom(ua => ua.Number));

            CreateMap<ClientGridModel, DeleteClientModel>();
            CreateMap<ClientGridModel, EditClientModel>().ForMember(ec => ec.Number, opts => opts.MapFrom(cg => cg.PhoneNumber));
        }
    }
}