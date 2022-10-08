using Domain.Material;
using Application.Features.MaterialFeatures.Dtos;
using AutoMapper;

namespace Application.Features.TripFeatures.Mappers
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialDto>().ReverseMap();
            CreateMap<Material, MaterialLiteDto>().ReverseMap();
            CreateMap<Material, CreateMaterialDto>().ReverseMap();
            CreateMap<Material, UpdateMaterialDto>().ReverseMap();



        }
    }
}
