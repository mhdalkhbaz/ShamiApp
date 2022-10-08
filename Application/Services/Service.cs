using Application.Common.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace Application.Services
{
    public class Service<TEntity, TEntityDto, TLiteEntityDto, TKey> : IService<TEntity, TEntityDto, TLiteEntityDto, TKey> where TEntity : class, IAuditableEntity<TKey>
    {
        protected readonly IRepository<TEntity, TKey> Repository;
        protected readonly IMapper Mapper;
        public Service(IRepository<TEntity, TKey> repository, IMapper mapper, IConfiguration configuration)
        {
            Repository = repository;
            Mapper = mapper;

        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Repository.AnyAsync(expression);
        }

        public async Task<PagingResultDto<TEntityDto>> GetPagingAsync(PagingDto? paging, params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var pagingResult = await Repository.GetPagingAsync(paging, propertySelectors);
            return new PagingResultDto<TEntityDto>(pagingResult.Total, Mapper.Map<IEnumerable<TEntityDto>>(pagingResult.Data));
        }

        public virtual async Task<PagingResultDto<TEntityDto>> GetPagingAsync(PagingDto? paging, string[] propertySelectors)
        {
            var pagingResult = await Repository.GetPagingAsync(paging, propertySelectors);
            return new PagingResultDto<TEntityDto>(pagingResult.Total, Mapper.Map<IEnumerable<TEntityDto>>(pagingResult.Data));
        }
        public virtual async Task<TEntityDto> GetByIdAsync(TKey id, string[] propertySelectors = null)
        {
            var entity = await Repository.GetByIdAsync(id, propertySelectors);
            if (entity == null) return default;
            var entityDto = Mapper.Map<TEntityDto>(entity);
            return entityDto;
        }

        public async Task<TEntityDto> GetByIdAsync(TKey id, string[] propertySelectors, params Expression<Func<TEntity, object>>[] linqPropertySelector)
        {
            var entity = await Repository.GetByIdAsync(id, propertySelectors, linqPropertySelector);
            if (entity == null) return default;
            var entityDto = Mapper.Map<TEntityDto>(entity);
            return entityDto;
        }

        public async Task<PagingResultDto<TEntityDto>> GetPagingAsync(PagingDto? paging, Expression<Func<TEntity, bool>> filter, string[] propertySelectors)
        {
            var entities = await Repository.GetPagingAsync(paging, filter, propertySelectors);
            return new PagingResultDto<TEntityDto>(entities.Total, Mapper.Map<IEnumerable<TEntityDto>>(entities.Data));
        }
        public async Task<IEnumerable<Projection>> Select<Projection>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, Projection>> projection, params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            return await Repository.Select(filter, projection, propertySelectors);
        }

        public async Task<PagingResultDto<TLiteEntityDto>> GetAllLiteAsync(PagingDto? paging, string[] propertySelectors)
        {
            var entities = await Repository.GetPagingAsync(paging, null, propertySelectors);
            return new PagingResultDto<TLiteEntityDto>(entities.Total, Mapper.Map<IEnumerable<TLiteEntityDto>>(entities.Data));
        }
    }
}
