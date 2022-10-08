using MediatR;
using Application.Features.MaterialFeatures.Dtos;

namespace Application.Features.MaterialFeatures.Commands
{
    public class UpdateMaterialCommand : IRequest
    {
        public UpdateMaterialCommand(UpdateMaterialDto updateMaterialDto)
        {
            UpdateMaterialDto = updateMaterialDto;
        }

        public UpdateMaterialDto UpdateMaterialDto { get; set; }

    }
}
