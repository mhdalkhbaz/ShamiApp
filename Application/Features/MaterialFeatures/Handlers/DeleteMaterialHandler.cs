using Application.Features.MaterialFeatures.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Material;
using MediatR;


namespace Application.Features.MaterialFeatures.Handlers
{
    public class DeleteMaterialHandler : IRequestHandler<DeleteMaterialCommand>
    {
        private readonly IRepository<Material, int> _repository;
        private readonly IMapper _mapper;
        public DeleteMaterialHandler(IMapper mapper, IRepository<Material, int> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
        {
            var Material = await _repository.GetByIdAsync(request.Id);
            _repository.SoftDelete(Material);
            return Unit.Value;
        }
    }
}
