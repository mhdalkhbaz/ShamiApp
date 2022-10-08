using Application.Features.MaterialFeatures.Dtos;
using Application.Features.MaterialFeatures.Commands;
using MediatR;
using Domain.Material;
using AutoMapper;

namespace Application.Features.MaterialFeatures.Handlers
{
    public class UpdateMaterialHandler : IRequestHandler<UpdateMaterialCommand>
    {
        private readonly  IMaterialService _MaterialService;
        public UpdateMaterialHandler(IMaterialService MaterialService)
        {
            _MaterialService = MaterialService;
        }
        public async Task<Unit> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            await _MaterialService.UpdateAsync(request.UpdateMaterialDto);
            return Unit.Value;
        }
    }
}
