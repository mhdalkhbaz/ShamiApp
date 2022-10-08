using Application.Common.Dtos;
using Application.Features.CategoryFeatures.Dtos;
using Application.Services;
using Domain.Material;

namespace Application.Features.CategoryFeatures
{
    public interface ICategoryService : ICRUDService<Category, CreateCategoryDto, UpdateCategoryDto, CategoryDto, CategoryLiteDto, int>
    {
        //Task<PagingResultDto<CategoryDto>> GetAll();
        //Task<CategoryDto> GetById(int id);


    }
}
