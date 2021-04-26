using AutoMapper;
using CarShowroom.Entities.DatabaseModels;
using CarShowroom.Entities.Models.AnswerModels.Vehicles;
using CarShowroom.Entities.Models.TransferModels.Vehicles;

namespace CarShowroom.Server.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<CreateVehicleModel, Vehicle>();

            CreateMap<Vehicle, VehicleAnswerModel>()
                .ForMember(v => v.IsSaled, opts => opts.MapFrom(v => v.Sale != null))
                .ForMember(v => v.IsMaintaining, opts => opts.MapFrom(v => v.Maintenance != null));
        }
    }
}