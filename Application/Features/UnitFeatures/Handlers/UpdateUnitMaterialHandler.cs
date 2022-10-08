using Application.Features.UnitMaterialFeatures.Dtos;
using Application.Features.UnitMaterialFeatures.Commands;
using MediatR;
using AutoMapper;

namespace Application.Features.UnitMaterialFeatures.Handlers
{
    public class UpdateUnitMaterialHandler : IRequestHandler<UpdateUnitMaterialCommand>
    {
        private readonly  IUnitMaterialService _UnitMaterialService;
        public UpdateUnitMaterialHandler(IUnitMaterialService UnitMaterialService)
        {
            _UnitMaterialService = UnitMaterialService;
        }
        public async Task<Unit> Handle(UpdateUnitMaterialCommand request, CancellationToken cancellationToken)
        {
            await _UnitMaterialService.UpdateAsync(request.UpdateUnitMaterialDto);
            return Unit.Value;
        }
    }
}
