using Domain.Material;
using SharedProject.Dtos;

namespace BlazorServer.Services
{
    public interface IServiceGeneric<TDto, T>
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetAsync(int id);
        Task AddAsync(TDto dto);
        Task UpdateAsync(TDto dto);
        Task DeleteAsync(int id);
    }
}
