using Application.Common.Dtos;
using Application.Features.UnitMaterialFeatures.Dtos;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Material;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application.Features.UnitMaterialFeatures
{
    public class UnitMaterialService : CRUDService<UnitMaterial, CreateUnitMaterialDto, UpdateUnitMaterialDto, UnitMaterialDto, UnitMaterialLiteDto, int>, IUnitMaterialService
    {

        private readonly IRepository<UnitMaterial, int> _repository;
        private readonly IMapper _mapper;
        public UnitMaterialService(IRepository<UnitMaterial, int> repository, 
                               IConfiguration configuration,
                               IMapper mapper
                               ) : base(repository, mapper, configuration)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //public async Task<PagingResultDto<UnitMaterialDto>> GetAll()
        //{
        //    var categories = _repository.GetAll();
        //    var UnitMaterialDtos = _mapper.Map<List<UnitMaterialDto>>(categories);
        //    var results = new PagingResultDto<UnitMaterialDto>(UnitMaterialDtos.Count(), UnitMaterialDtos);
        //    return results;
        //}

    }
}
