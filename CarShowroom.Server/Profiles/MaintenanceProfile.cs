using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels;
using CarShowroom.Entities.Models.AnswerModels.Maintenances;

namespace CarShowroom.Server.Profiles
{
    public class MaintenanceProfile : Profile
    {
        public MaintenanceProfile()
        {
            CreateMap<Maintenance, MaintenanceAnswerModel>();
            //CreateMap<List<Maintenance>, MaintenanceStatisticAnswerModel>().ForMember(ms => ms.TotalCost, 
            //    opts => opts.MapFrom(ml => ml.Select(m => m).Where(m => m.)))
        }
    }
}