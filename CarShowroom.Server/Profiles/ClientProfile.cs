using System.Linq;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels;
using CarShowroom.Entities.Models.AnswerModels.Clients;
using CarShowroom.Entities.Models.Enums;

namespace CarShowroom.Server.Profiles
{
    class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientAnswerModel>().ForMember(c => c.Name, opts => opts.MapFrom(cm => cm.User.Name))
                .ForMember(c => c.HaveMaintenances, opts => opts.MapFrom(cm => cm.Maintenances.Count > 0))
                .ForMember(c => c.HaveSales, opts => opts.MapFrom(cm => cm.Sales.Count > 0 && cm.Sales.Any(s => s.Status == SaleStatus.Accepted)));

            CreateMap<Client, ClientDealsAnswerModel>().ForMember(c => c.Maintenances, opts => opts.MapFrom(d => d.Maintenances))
                .ForMember(c => c.Sales, opts => opts.MapFrom(d => d.Sales))
                .ForMember(c => c.Name, opts => opts.MapFrom(d => d.User.Name));
        }
    }
}