using Application.Common.Dtos;
using Application.Features.UnitMaterialFeatures.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitMaterialFeatures.Queries
{
    public class GetAllUnitMaterialQuery : IRequest<PagingResultDto<UnitMaterialDto>>
    {

    }
}
