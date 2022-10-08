using Application.Common.Dtos;
using Domain.Common;
using System.Linq.Expressions;

namespace Application.Services
{
    public interface IService<TEntity, TEntityDto, TLiteEntityDto, TKey> where TEntity : IAuditableEntity<TKey>
    {
        Task<PagingResultDto<TEntityDto>> GetPagingAsync(PagingDto? paging, params Expression<Func<TEntity, object>>[] propertySelectors);
        Task<PagingResultDto<TEntityDto>> GetPagingAsync(PagingDto? paging, string[] propertySelectors);
        Task<PagingResultDto<TEntityDto>> GetPagingAsync(PagingDto? paging, Expression<Func<TEntity, bool>> filter, string[] propertySelectors);
        Task<PagingResultDto<TLiteEntityDto>> GetAllLiteAsync(PagingDto? paging, string[] propertySelectors);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntityDto> GetByIdAsync(TKey id, string[] propertySelectors=null);
        Task<TEntityDto> GetByIdAsync(TKey id, string[] propertySelectors,params Expression<Func<TEntity, object>>[] linqPropertySelector);
        Task<IEnumerable<Projection>> Select<Projection>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, Projection>> projection, params Expression<Func<TEntity, object>>[] propertySelectors);
    }
}
