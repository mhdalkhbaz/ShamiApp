using Domain.Material;
using Application.Features.CategoryFeatures.Dtos;
using AutoMapper;

namespace Application.Features.TripFeatures.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryLiteDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();



        }
    }
}
