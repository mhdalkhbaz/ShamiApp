using Domain.Common;
using Application.Common;
using Application.Common.Dtos;

namespace Application.Services
{
    public interface ICRUDService<TEntity, TCreateEntity, TUpdateEntity, TEntityDto, TLiteEntityDto, TKey> : IService<TEntity,TEntityDto, TLiteEntityDto,TKey>
        where TEntity : IAuditableEntity<TKey>
        //where TUpdateEntity : EntityDto<TKey>
        
    {
        Task<TEntityDto> CreateAsync(TCreateEntity command);
        Task<TEntityDto> UpdateAsync(TUpdateEntity command, string[] propertySelectors=null);
        Task<TEntityDto> UpdateTestAsync(TUpdateEntity command);
        //Task<TKey> DeleteAsync(TKey id);
        //void Delete(TEntity entity);
    }
}
