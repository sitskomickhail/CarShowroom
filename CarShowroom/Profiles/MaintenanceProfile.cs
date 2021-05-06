using AutoMapper;
using CarShowroom.Entities.Models.AnswerModels.Maintenances;
using CarShowroom.Entities.Models.TransferModels.Maintenances;
using CarShowroom.Models.Maintenances;

namespace CarShowroom.Profiles
{
    public class MaintenanceProfile : Profile
    {
        public MaintenanceProfile()
        {
            CreateMap<MaintenanceAnswerModel, MaintenanceGridModel>()
                .ForMember(g => g.Client, opts => opts.MapFrom(m => m.Client.Name))
                .ForMember(g => g.Vehicle, opts => opts.MapFrom(m => $"{m.Vehicle.Mark} {m.Vehicle.Model}"));

            CreateMap<MaintenanceGridModel, EditMaintenanceModel>();
            CreateMap<MaintenanceStatisticAnswerModel, MaintenanceStatisticsGridModel>()
                .ForMember(v => v.Vehicle, opts => opts.MapFrom(v => v.VehicleMark));
        }
    }
}