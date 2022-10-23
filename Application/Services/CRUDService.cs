using AutoMapper;
using Application.Common;
using Domain.Common;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class CRUDService<TEntity, TCreateEntity, TUpdateEntity, TEntityDto, TLiteEntityDto, TKey>
        : Service<TEntity, TEntityDto, TLiteEntityDto, TKey>, ICRUDService<TEntity, TCreateEntity, TUpdateEntity, TEntityDto, TLiteEntityDto, TKey>
        where TEntity : class, IAuditableEntity<TKey>
        where TUpdateEntity : IEntityDto<TKey>
    {
        protected readonly IRepository<TEntity, TKey> Repository;
        protected readonly IMapper Mapper;
        public CRUDService(IRepository<TEntity, TKey> repository,
                       IMapper mapper,  IConfiguration configuration)
            : base(repository, mapper,  configuration)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public virtual async Task<TEntityDto> CreateAsync(TCreateEntity createEntity)
        {
            
            var entity = Mapper.Map<TEntity>(createEntity);
            await Repository.AddAsync(entity);
            await Repository.SaveChangesAsync();
            var entityDto = Mapper.Map<TEntityDto>(entity);
            return entityDto;
        }

        public async Task<TEntityDto> UpdateAsync(TUpdateEntity updateEntity, string[] propertySelectors)
        {
        
            var entity = await Repository.GetByIdAsync(updateEntity.Id, propertySelectors);
            entity = Mapper.Map<TUpdateEntity, TEntity>(updateEntity, entity);
            if (entity == null)
            {
                return default;
            }
            else
            {
                Repository.Update(entity);
                ///we need for it in update 
                ///example if we update a list of object inside an aggregate root object 
                ///like add a new region for a city
                ///then we need for the genarated id of the new entity (region)
                await Repository.SaveChangesAsync();
                var entityDto = Mapper.Map<TEntityDto>(entity);
                return entityDto;
            }
        }

        public async Task<TEntityDto> UpdateTestAsync(TUpdateEntity updateEntity)
        {
            var entity = await Repository.GetByIdAsync(updateEntity.Id);
            entity = Mapper.Map<TUpdateEntity, TEntity>(updateEntity, entity);

            Repository.Update(entity);
                ///we need for it in update 
                ///example if we update a list of object inside an aggregate root object 
                ///like add a new region for a city
                ///then we need for the genarated id of the new entity (region)
                await Repository.SaveChangesAsync();
                var entityDto = Mapper.Map<TEntityDto>(entity);
                return entityDto;
            }
        }
    }
