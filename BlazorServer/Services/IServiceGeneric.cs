using Domain.Material;
using SharedProject.Dtos;

namespace BlazorServer.Services
{
    public interface IServiceGeneric<TDto, T, TCreateDto, TUpdateDto>
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetAsync(int id);
        Task AddAsync(TCreateDto createDto);
        Task UpdateAsync(TUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
