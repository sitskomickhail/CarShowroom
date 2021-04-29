using AutoMapper;
using CarShowroom.Entities.DatabaseModels;
using CarShowroom.Entities.Models.AnswerModels.Sales;

namespace CarShowroom.Server.Profiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<Sale, SaleAnswerModel>();
        }
    }
}