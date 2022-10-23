using Application.Common.Dtos;
using Domain.Common;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IRepository<TEntity, in TKey> : IBaseRepository<TEntity, TKey> where TEntity : class, IAuditableEntity<TKey>
    {
        Task<TEntity?> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] propertySelectors);
        Task<TEntity?> GetByIdAsync(TKey id, string[] propertySelectors);
        Task<TEntity?> GetByIdAsync(TKey id, string[] propertySelectors1, params Expression<Func<TEntity, object>>[] propertySelectors2);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> GetAll();
        
        Task<List<TEntity>> GetAllListAsync(string[] propertySelectors, Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression);
        
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void SoftDelete(TEntity entity);
        //void Remove(TEntity entity);
        //void RemoveRange(IEnumerable<TEntity> entities);
        Task SaveChangesAsync();
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<Projection>> Select<Projection>(Expression<Func<TEntity, Projection>> selector, Expression<Func<TEntity, bool>> filter);
        Task Reload(TEntity entity);
    }
}
