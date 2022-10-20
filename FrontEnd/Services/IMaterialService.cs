using Domain.Material;


namespace FrontEnd.Services
{
    public interface IMaterialService
    {
        Task<IEnumerable<Material>> GetAllMaterials();
        Task<Material> GetMaterial(int id);
        Task<Material> AddMaterial(Material material);
        Task UpdateMaterial(Material material);
        Task DeleteMaterial(int id);


    }
}
