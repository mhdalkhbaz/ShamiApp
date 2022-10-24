using Domain.Material;
using SharedProject.Dtos;

namespace BlazorServer.Services
{
    public interface IServiceGeneric<TDto, T, TCreateDto>
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetAsync(int id);
        Task AddAsync(TCreateDto createDto);
        Task UpdateAsync(TDto dto);
        Task DeleteAsync(int id);
    }
}
