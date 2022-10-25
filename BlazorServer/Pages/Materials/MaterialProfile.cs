using Domain.Material;
using AutoMapper;
using SharedProject.Dtos;

namespace BlazorServer.Pages.Materials
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialDto>().ReverseMap();
            CreateMap<Material, MaterialLiteDto>().ReverseMap();
            CreateMap<MaterialDto, CreateMaterialDto>().ReverseMap();
            CreateMap<MaterialDto, UpdateMaterialDto>().ReverseMap();

            CreateMap<CategoryDto, CreateCategoryDto>().ReverseMap();
            CreateMap<CategoryDto, UpdateCategoryDto>().ReverseMap();

            CreateMap<UnitMaterialDto, CreateUnitMaterialDto>().ReverseMap();
            CreateMap<UnitMaterialDto, UpdateUnitMaterialDto>().ReverseMap();

        }
    }
}
