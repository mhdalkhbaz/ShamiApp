using Application.Features.UnitMaterialFeatures.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Material;
using MediatR;


namespace Application.Features.UnitMaterialFeatures.Handlers
{
    public class DeleteUnitMaterialHandler : IRequestHandler<DeleteUnitMaterialCommand>
    {
        private readonly IRepository<UnitMaterial, int> _repository;
        private readonly IMapper _mapper;
        public DeleteUnitMaterialHandler(IMapper mapper, IRepository<UnitMaterial, int> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteUnitMaterialCommand request, CancellationToken cancellationToken)
        {
            var UnitMaterial = await _repository.GetByIdAsync(request.Id);
            _repository.SoftDelete(UnitMaterial);
            return Unit.Value;
        }
    }
}
