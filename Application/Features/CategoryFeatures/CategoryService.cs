using Application.Common.Dtos;
using Application.Features.CategoryFeatures.Dtos;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Material;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application.Features.CategoryFeatures
{
    public class CategoryService : CRUDService<Category, CreateCategoryDto, UpdateCategoryDto, CategoryDto, CategoryLiteDto, int>, ICategoryService
    {

        private readonly IRepository<Category, int> _repository;
        private readonly IMapper _mapper;
        public CategoryService(IRepository<Category, int> repository, 
                               IConfiguration configuration,
                               IMapper mapper
                               ) : base(repository, mapper, configuration)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task DeleteAsync(int id)
        {
            var categoryDto = await GetByIdAsync(id);
            var category = _mapper.Map<Category>(categoryDto);
            category.IsDeleted = true;
            category.Name = "ssssssssssss";
            category.CreatedBy = "ssssssssssss";
            _repository.Update(category);
        }
        public async Task UpdatsseAsync(int id)
        {
            var categoryDto = await GetByIdAsync(id);
            var category = _mapper.Map<Category>(categoryDto);
            category.IsDeleted = true;
            category.Name = "ssssssssssss";
            category.CreatedBy = "ssssssssssss";
        }


        //public async Task<PagingResultDto<CategoryDto>> GetAll()
        //{
        //    var categories = _repository.GetAll();
        //    var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);
        //    var results = new PagingResultDto<CategoryDto>(categoryDtos.Count(), categoryDtos);
        //    return results;
        //}

    }
}
