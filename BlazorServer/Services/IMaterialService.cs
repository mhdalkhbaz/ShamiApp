using Domain.Material;
using SharedProject.Dtos;

namespace BlazorServer.Services
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialDto>> GetAllMaterials();
        Task<Material> GetMaterial(int id);
        Task<Material> AddMaterial(Material material);
        Task UpdateMaterial(Material material);
        Task DeleteMaterial(int id);
    }
}
