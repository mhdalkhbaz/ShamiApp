using BlazorServer.Pages.Categories;
using Domain.Material;
using SharedProject.Dtos;
using SharedProject.Dtos.Common;
using System.Diagnostics;
using System.Net.Http.Json;

namespace BlazorServer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CategoryDto> AddCategoryAsync(CategoryDto category)
        {
            var categoryDto = new CategoryDto();
            try
            {
               var httpResponseMessage = await _httpClient.PostAsJsonAsync<CategoryDto>("api/Category",category);
            }
            catch (Exception exception)
            {
                var ss = exception.Message;
                throw new Exception(exception.Message);
            }
            return categoryDto;
        }
        public async Task UpdateCategoryAsync(CategoryDto category)
        {
            try
            {
                var httpResponseMessage = await _httpClient.PutAsJsonAsync<CategoryDto>("api/Category", category);
            }
            catch (Exception exception)
            {
                var ss = exception.Message;
                throw new Exception(exception.Message);
            }
        }


        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            IEnumerable<CategoryDto> categories;
            try
            {
               var categorylist  = await _httpClient.GetFromJsonAsync<PagingResultDto<CategoryDto>>("api/Category/get-all");
                categories = categorylist.Data;
            }
            catch (Exception exception)
            {
                var ss = exception.Message;
                throw new Exception(exception.Message);
            }
            return categories;
        }

        public Task<CategoryDto> GetCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteCategoryAsync(int ssada)
        {
           var tt =  await _httpClient.PutAsJsonAsync<int>("api/Category/delete-id" , ssada); 
        }
    }
}
