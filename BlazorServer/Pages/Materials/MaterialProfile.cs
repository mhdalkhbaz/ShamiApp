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
            CreateMap<Material, UpdateMaterialDto>().ReverseMap();



        }
    }
}
