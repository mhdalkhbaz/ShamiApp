using Application.Common.Dtos;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Extensions;
using System.Linq.Expressions;
using System.Text;

namespace Persistence.Repositories
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<IEnumerable<Projection>> Select<Projection>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, Projection>> projection, params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var query = _dbSet.AsQueryable();
            if (filter != null)
                query = query.Where(filter);
            query = Include(query, propertySelectors);
            return await query.Select(projection).ToListAsync();
        }

        public async Task<TEntity?> FindFirstAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.Where(expression).FirstOrDefaultAsync();
        }
        public async Task<List<TEntity>> GetAllListAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task LoadRefernces<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression) where TProperty : class
        {
            await _context.Entry(entity).Reference(propertyExpression).LoadAsync();
        }
        public TEntity Attach(TEntity entity)
        {
            return _context.Attach(entity).Entity;
        }

        public async Task LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression) where TProperty : class
        {
            await _context.Entry(entity).Collection(propertyExpression).LoadAsync();
        }

        public async Task<PagingResultDto<TEntity>> GetPagingAsync(PagingDto? pagingDto, params Expression<Func<TEntity, object>>[] propertySelectors)
        {

            var total = await _dbSet.CountAsync();
            var query = _dbSet.AsQueryable();
            query = Include(query, propertySelectors);
            IEnumerable<TEntity> data = (pagingDto == null || (pagingDto.PageIndex == 0 && pagingDto.PageSize == 0)) ? await query.ToListAsync() : await query.Skip((pagingDto.PageIndex * (pagingDto.PageSize - 1))).Take(pagingDto.PageSize).ToListAsync();
            return new PagingResultDto<TEntity>(total, data);
        }

        public async Task<PagingResultDto<TEntity>> GetPagingAsync(PagingDto? pagingDto, string[] propertySelectors)
        {
            var total = await _dbSet.CountAsync();
            var query = _dbSet.AsQueryable();
            query = Include(query, propertySelectors);
            IEnumerable<TEntity> data = (pagingDto == null || (pagingDto.PageIndex == 0 && pagingDto.PageSize == 0)) ? await query.ToListAsync() : await query.Skip((pagingDto.PageIndex * (pagingDto.PageSize - 1))).Take(pagingDto.PageSize).ToListAsync();
            return new PagingResultDto<TEntity>(total, data);

        }

        public async Task<bool> IsFoundAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
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
        public async Task<PagingResultDto<TEntity>> GetPagingAsync(PagingDto? pagingDto, Expression<Func<TEntity, bool>> expression, string[] propertySelectors = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var query = _dbSet.AsQueryable();

            if (orderBy != null)
            {
                query = orderBy(query).AsQueryable();
            }
            
            if (expression != null)
                query = query.Where(expression);

            query = Include(query, propertySelectors);
            var count = await query.CountAsync();
            var data = (pagingDto == null || (pagingDto.PageSize == 0 && pagingDto.PageSize == 0)) ? await query.ToListAsync() : await query.Paging(pagingDto).ToListAsync();
            return new PagingResultDto<TEntity>(count, data);
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


    }
}
