using Application.Features.MaterialFeatures.Dtos;
using Application.Features.MaterialFeatures.Queries;
using AutoMapper;
using Domain.Material;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialFeatures.Handlers
{
    public class GetMaterialByIdHandler : IRequestHandler<GetMaterialByIdQuery, MaterialDto>
    {
        private readonly IMaterialService _MaterialService;
        private readonly IMapper _mapper;
        public GetMaterialByIdHandler(IMaterialService MaterialService, IMapper mapper)
        {
            _MaterialService = MaterialService;
            _mapper = mapper;
        }
        string[] include = { nameof(Category), nameof(UnitMaterial) };
        public async Task<MaterialDto> Handle(GetMaterialByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _MaterialService.GetByIdAsync(request.Id, include);
            return entity;
        }
    }
}
