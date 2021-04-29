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
        }
    }
}