using Application.Common.Dtos;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IBaseRepository<TEntity, in TKey> where TEntity : class
    {
        Task<PagingResultDto<TEntity>> GetPagingAsync(PagingDto? pagingDto, params Expression<Func<TEntity, object>>[] propertySelectors);
        Task<PagingResultDto<TEntity>> GetPagingAsync(PagingDto? pagingDto, string[] propertySelectors);
        Task<PagingResultDto<TEntity>> GetPagingAsync(PagingDto? pagingDto, Expression<Func<TEntity, bool>> expression, string[] propertySelectors = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<bool> IsFoundAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity?> FindFirstAsync(Expression<Func<TEntity, bool>> expression);
        Task LoadRefernces<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression) where TProperty : class;
        Task LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression) where TProperty : class;
        TEntity Attach(TEntity entity);
        Task<List<TEntity>> GetAllListAsync();
        Task<IEnumerable<Projection>> Select<Projection>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, Projection>> projection, params Expression<Func<TEntity, object>>[] propertySelectors);
    }
}
