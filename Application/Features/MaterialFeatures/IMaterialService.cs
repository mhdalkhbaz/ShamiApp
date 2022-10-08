using Application.Common.Dtos;
using Application.Features.MaterialFeatures.Dtos;
using Application.Services;
using Domain.Material;

namespace Application.Features.MaterialFeatures
{
    public interface IMaterialService : ICRUDService<Material, CreateMaterialDto, UpdateMaterialDto, MaterialDto, MaterialLiteDto, int>
    {
        //Task<PagingResultDto<MaterialDto>> GetAll();
        //Task<MaterialDto> GetById(int id);


    }
}
