using Application.Features.UnitMaterialFeatures.Dtos;
using Application.Features.UnitMaterialFeatures.Commands;
using MediatR;
using Domain.Material;
using AutoMapper;

namespace Application.Features.UnitMaterialFeatures.Handlers
{
    public class CreateUnitMaterialHandler : IRequestHandler<CreateUnitMaterialCommand, UnitMaterialDto>
    {
        private readonly  IUnitMaterialService _UnitMaterialService;
        public CreateUnitMaterialHandler(IUnitMaterialService UnitMaterialService)
        {
            _UnitMaterialService = UnitMaterialService;
        }
        public async Task<UnitMaterialDto> Handle(CreateUnitMaterialCommand request, CancellationToken cancellationToken)
        {
            var entity = await _UnitMaterialService.CreateAsync(request.CreateUnitMaterialDto);
            return entity ;
        }
     
    }
}
