using Application.Common.Dtos;
using Application.Features.UnitMaterialFeatures.Dtos;
using Application.Services;
using Domain.Material;

namespace Application.Features.UnitMaterialFeatures
{
    public interface IUnitMaterialService : ICRUDService<UnitMaterial, CreateUnitMaterialDto, UpdateUnitMaterialDto, UnitMaterialDto, UnitMaterialLiteDto, int>
    {
        //Task<PagingResultDto<UnitMaterialDto>> GetAll();
        //Task<UnitMaterialDto> GetById(int id);


    }
}
