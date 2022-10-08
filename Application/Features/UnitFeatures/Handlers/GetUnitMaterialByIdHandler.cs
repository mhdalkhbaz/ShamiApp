using Application.Features.UnitMaterialFeatures.Dtos;
using Application.Features.UnitMaterialFeatures.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitMaterialFeatures.Handlers
{
    public class GetUnitMaterialByIdHandler : IRequestHandler<GetUnitMaterialByIdQuery, UnitMaterialDto>
    {
        private readonly IUnitMaterialService _UnitMaterialService;
        public GetUnitMaterialByIdHandler(IUnitMaterialService UnitMaterialService)
        {
            _UnitMaterialService = UnitMaterialService;
        }

        public Task<UnitMaterialDto> Handle(GetUnitMaterialByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = _UnitMaterialService.GetByIdAsync(request.Id);
            return entity;
        }
    }
}
