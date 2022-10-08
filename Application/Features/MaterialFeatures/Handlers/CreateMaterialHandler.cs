using Application.Features.MaterialFeatures.Dtos;
using Application.Features.MaterialFeatures.Commands;
using MediatR;
using Domain.Material;
using AutoMapper;

namespace Application.Features.MaterialFeatures.Handlers
{
    public class CreateMaterialHandler : IRequestHandler<CreateMaterialCommand, MaterialDto>
    {
        private readonly  IMaterialService _MaterialService;
        public CreateMaterialHandler(IMaterialService MaterialService)
        {
            _MaterialService = MaterialService;
        }
        public async Task<MaterialDto> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            var entity = await _MaterialService.CreateAsync(request.CreateMaterialDto);
            return entity ;
        }
     
    }
}
