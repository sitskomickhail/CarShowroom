using System;
using AutoMapper;
using CarShowroom.Entities.Models.AnswerModels.Sales;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Models.Sales;

namespace CarShowroom.Profiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<SaleAnswerModel, SaleGridModel>()
                .ForMember(sg => sg.Vehicle, opts => opts.MapFrom(v => $"{v.Vehicle.Mark} {v.Vehicle.Model}"))
                .ForMember(sg => sg.Client, opts => opts.MapFrom(c => c.Client.Name))
                .ForMember(sg => sg.Status, opts => opts.MapFrom(c => Enum.GetName(typeof(SaleStatus), c.Status)));
        }
    }
}