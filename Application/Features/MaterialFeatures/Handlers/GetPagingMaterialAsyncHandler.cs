using Application.Common.Dtos;
using Application.Features.MaterialFeatures.Dtos;
using Application.Features.MaterialFeatures.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialFeatures.Handlers
{
    public class GetPagingMaterialAsyncHandler : IRequestHandler<GetPagingMaterialAsyncQuery, PagingResultDto<MaterialDto>>
    {
        private readonly IMaterialService _MaterialService;
        public GetPagingMaterialAsyncHandler(IMaterialService MaterialService)
        {
            _MaterialService = MaterialService;
        }
        public async Task<PagingResultDto<MaterialDto>> Handle(GetPagingMaterialAsyncQuery request, CancellationToken cancellationToken)
        {
            return await _MaterialService.GetPagingAsync(request.PagingDto);
        }
    }
}
