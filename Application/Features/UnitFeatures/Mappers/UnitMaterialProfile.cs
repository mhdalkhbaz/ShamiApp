using Domain.Material;
using Application.Features.UnitMaterialFeatures.Dtos;
using AutoMapper;

namespace Application.Features.TripFeatures.Mappers
{
    public class UnitMaterialProfile : Profile
    {
        public UnitMaterialProfile()
        {
            CreateMap<UnitMaterial, UnitMaterialDto>().ReverseMap();
            CreateMap<UnitMaterial, UnitMaterialLiteDto>().ReverseMap();
            CreateMap<UnitMaterial, CreateUnitMaterialDto>().ReverseMap();
            CreateMap<UnitMaterial, UpdateUnitMaterialDto>().ReverseMap();



        }
    }
}
