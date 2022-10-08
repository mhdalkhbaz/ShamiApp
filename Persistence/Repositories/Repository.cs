using Domain.Common;
using Persistence.Context;
using Application.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Application.Common.Dtos;
using Persistence.Extensions;

namespace Persistence.Repositories
{
    public class Repository<TEntity, TKey> : BaseRepository<TEntity, int>, IRepository<TEntity, TKey> where TEntity : AuditableEntity<TKey>
    {
        protected readonly ApplicationDbContext _context;
        private readonly IQueryable<TEntity> _query;

        public Repository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _query = _context.Set<TEntity>().Where(c => c.IsDeleted == false);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _query.ToListAsync();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _query.ToList();
        }

        public async Task<List<TEntity>> GetAllListAsync(string[] propertySelectors, Expression<Func<TEntity, bool>> expression)
        {
            var query = _query.AsQueryable();
            query = Include(query, propertySelectors);
            return await query.Where(expression).ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _query.Where(expression).ToListAsync();
        }



        public async Task AddAsync(TEntity entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;
            //TODO: fill CreatedBy and LastModifiedBy
            await _context.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreatedOn = DateTime.UtcNow;
                entity.LastModifiedOn = DateTime.UtcNow;
                //TODO: fill CreatedBy and LastModifiedBy   
            }
            await _context.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            entity.LastModifiedOn = DateTime.UtcNow;
            //TODO: fill LastModifiedBy
            _context.Update(entity);
        }
        public async Task Reload(TEntity entity)
        {
            await _context.Entry(entity).ReloadAsync();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.LastModifiedOn = DateTime.UtcNow;
                //TODO: fill LastModifiedBy   
            }
            _context.UpdateRange(entities);
        }


        public async Task<PagingResultDto<TEntity>> GetPagingAsync(PagingDto? pagingDto, params Expression<Func<TEntity, object>>[] propertySelectors)
        {

            var total = await _query.CountAsync();
            var query = _query.AsQueryable();
            query = Include(query, propertySelectors);
            var data = (pagingDto == null || pagingDto.PageIndex == 0 && pagingDto.PageSize == 0) ? await query.ToListAsync() : await query.Paging(pagingDto).ToListAsync();
            return new PagingResultDto<TEntity>(total, data);
        }

        public async Task<PagingResultDto<TEntity>> GetPagingAsync(PagingDto? pagingDto, string[] propertySelectors)
        {
            var total = await _query.CountAsync();
            var query = _query.AsQueryable();
            query = Include(query, propertySelectors);
            var data = (pagingDto == null || pagingDto.PageIndex == 0 && pagingDto.PageSize == 0) ? await query.ToListAsync() : await query.Paging(pagingDto).ToListAsync();
            return new PagingResultDto<TEntity>(total, data);

        }
        public Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<TKey> ids)
        {
            throw new NotImplementedException();
        }


        #region  Private Methods
        private void DeleteSoft(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
            // TODO: Set DeletedBy
            _context.Update(entity);
        }
        private void DeleteSoft(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.DeletedOn = DateTime.UtcNow;
                // TODO: Set DeletedBy
            }
            _context.UpdateRange(entities);
        }
        private static IQueryable<TEntity> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            if (propertySelectors != null)
            {
                foreach (var item in propertySelectors)
                {
                    query = query.Include(item.AsPath());
                }

            }
            return query;
        }
        private static IQueryable<TEntity> Include(IQueryable<TEntity> query, string[] propertySelectors)
        {
            if (propertySelectors?.Any() == true)
            {
                foreach (var item in propertySelectors)
                {
                    query = query.Include(item);
                }
            }
            return query;
        }

        public async Task<TEntity?> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var query = _query.AsQueryable();
            query = Include(query, propertySelectors);
            query = query.Where(c => c.Id.Equals(id));
            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id, string[] propertySelectors)
        {
            var query = _query.AsQueryable();
            query = Include(query, propertySelectors);
            query = query.Where(c => c.Id.Equals(id));
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _query.AnyAsync(expression);
        }

        public async Task<TEntity?> GetByIdAsync(TKey id, string[] propertySelectors1, params Expression<Func<TEntity, object>>[] propertySelectors2)
        {
            var query = _query.AsQueryable();
            query = Include(query, propertySelectors1);
            query = Include(query, propertySelectors2);
            query = query.Where(c => c.Id.Equals(id));
            return await query.FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Projection>> Select<Projection>(Expression<Func<TEntity, Projection>> selector, Expression<Func<TEntity, bool>> filter)
        {
            var query = _query.AsQueryable();
            if (filter != null)
                query = query.Where(filter);
            return await query.Select(selector).ToListAsync();
        }







        #endregion
    }
}
