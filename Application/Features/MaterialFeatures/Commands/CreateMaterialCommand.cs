using MediatR;
using Application.Features.MaterialFeatures.Dtos;

namespace Application.Features.MaterialFeatures.Commands
{
    public class CreateMaterialCommand : IRequest<MaterialDto>
    {
        public CreateMaterialCommand(CreateMaterialDto createMaterialDto)
        {
            CreateMaterialDto = createMaterialDto;
        }

        public CreateMaterialDto CreateMaterialDto { get; set; }

    }
}
