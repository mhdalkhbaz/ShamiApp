using MediatR;
using Application.Features.UnitMaterialFeatures.Dtos;

namespace Application.Features.UnitMaterialFeatures.Commands
{
    public class CreateUnitMaterialCommand : IRequest<UnitMaterialDto>
    {
        public CreateUnitMaterialCommand(CreateUnitMaterialDto createUnitMaterialDto)
        {
            CreateUnitMaterialDto = createUnitMaterialDto;
        }

        public CreateUnitMaterialDto CreateUnitMaterialDto { get; set; }

    }
}
