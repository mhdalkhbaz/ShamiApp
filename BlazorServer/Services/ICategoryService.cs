using Domain.Material;
using SharedProject.Dtos;

namespace BlazorServer.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategories();
        Task<CategoryDto> GetCategoryAsync(int id);
        Task<CategoryDto> AddCategoryAsync(CategoryDto Category);
        Task UpdateCategoryAsync(CategoryDto Category);
        Task DeleteCategoryAsync(int id);
    }
}
