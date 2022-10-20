using Domain.Material;

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


        public async Task<IEnumerable<Material>> GetAllMaterials()
        {
            IEnumerable<Material> materials;
            try
            {
                materials = await _httpClient.GetFromJsonAsync<IEnumerable<Material>>("api/Material");
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
