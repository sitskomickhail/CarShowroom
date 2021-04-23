using AutoMapper;
using CarShowroom.Entities.Models.AnswerModels.Vehicles;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Models.Vehicles;

namespace CarShowroom.Mappers
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleAnswerModel, VehicleGridModel>();
            CreateMap<VehicleGridModel, EditVehicleModel>();
        }
    }
}