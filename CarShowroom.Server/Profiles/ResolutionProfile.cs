using AutoMapper;
using CarShowroom.Entities.DatabaseModels;
using CarShowroom.Entities.Models.AnswerModels.Resolutions;

namespace CarShowroom.Server.Profiles
{
    public class ResolutionProfile : Profile
    {
        public ResolutionProfile()
        {
            CreateMap<Resolution, ResolutionValuesAnswerModel>();
        }
    }
}