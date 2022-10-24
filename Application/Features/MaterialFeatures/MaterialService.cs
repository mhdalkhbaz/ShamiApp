using Application.Common;
using Application.Common.Dtos;
using Application.Features.MaterialFeatures.Dtos;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Material;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application.Features.MaterialFeatures
{
    public class MaterialService : CRUDService<Material, CreateMaterialDto, UpdateMaterialDto, MaterialDto, MaterialLiteDto, int>, IMaterialService
    {

        private readonly IRepository<Material, int> _repository;
        private readonly IRepository<Category, int> _CategoryRepository;
        private readonly IRepository<UnitMaterial, int> _UnitMaterialRepository;
        private readonly IMapper _mapper;
        public MaterialService(IRepository<Material, int> repository,
                               IConfiguration configuration,
                               IMapper mapper,
                               IRepository<UnitMaterial, int> unitMaterialRepository,
                               IRepository<Category, int> categoryRepository) : base(repository, mapper, configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _UnitMaterialRepository = unitMaterialRepository;
            _CategoryRepository = categoryRepository;
        }

        //public async Task<PagingResultDto<MaterialDto>> GetAll()
        //{
        //    var categories = _repository.GetAll();
        //    var MaterialDtos = _mapper.Map<List<MaterialDto>>(categories);
        //    var results = new PagingResultDto<MaterialDto>(MaterialDtos.Count(), MaterialDtos);
        //    return results;
        //}

        public override async Task<MaterialDto> CreateAsync(CreateMaterialDto createEntity)
        {
            var entity = _mapper.Map<Material>(createEntity);
          
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            var entityDto = new MaterialDto();
            return entityDto;

        }

    }
}
