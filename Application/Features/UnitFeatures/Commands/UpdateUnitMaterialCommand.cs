using MediatR;
using Application.Features.UnitMaterialFeatures.Dtos;

namespace Application.Features.UnitMaterialFeatures.Commands
{
    public class UpdateUnitMaterialCommand : IRequest
    {
        public UpdateUnitMaterialCommand(UpdateUnitMaterialDto updateUnitMaterialDto)
        {
            UpdateUnitMaterialDto = updateUnitMaterialDto;
        }

        public UpdateUnitMaterialDto UpdateUnitMaterialDto { get; set; }

    }
}
