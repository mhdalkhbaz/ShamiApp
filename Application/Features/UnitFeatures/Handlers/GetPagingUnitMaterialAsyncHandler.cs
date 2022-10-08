using Application.Common.Dtos;
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
    public class GetPagingUnitMaterialAsyncHandler : IRequestHandler<GetPagingUnitMaterialAsyncQuery, PagingResultDto<UnitMaterialDto>>
    {
        private readonly IUnitMaterialService _UnitMaterialService;
        public GetPagingUnitMaterialAsyncHandler(IUnitMaterialService UnitMaterialService)
        {
            _UnitMaterialService = UnitMaterialService;
        }
        public async Task<PagingResultDto<UnitMaterialDto>> Handle(GetPagingUnitMaterialAsyncQuery request, CancellationToken cancellationToken)
        {
            return await _UnitMaterialService.GetPagingAsync(request.PagingDto);
        }
    }
}
