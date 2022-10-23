using Domain.Material;
using Microsoft.AspNetCore.WebUtilities;
using SharedProject.Dtos;
using SharedProject.Dtos.Common;
using static System.Net.WebRequestMethods;

namespace BlazorServer.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly HttpClient _httpClient;
        public MaterialService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Material> AddMaterial(Material material)
        {
            throw new NotImplementedException();
        }
        public Task UpdateMaterial(Material material)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<MaterialDto>> GetAllMaterials()
        {
            IEnumerable<MaterialDto> materials;
            try
            {
               var materialList = await _httpClient.GetFromJsonAsync<PagingResultDto<MaterialDto>>("api/Material/get-all");
                materials = materialList.Data;
            }
            catch (Exception exception)
            {
                var ss = exception.Message;
                throw new Exception(exception.Message);
            }
            return materials;
        }

        public Task<Material> GetMaterial(int id)
        {
            throw new NotImplementedException();
        }
        public Task DeleteMaterial(int id)
        {
            throw new NotImplementedException();
        }
    }
}
