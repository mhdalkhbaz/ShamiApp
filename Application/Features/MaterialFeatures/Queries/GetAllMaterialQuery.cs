using Application.Common.Dtos;
using Application.Features.MaterialFeatures.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialFeatures.Queries
{
    public class GetAllMaterialQuery : IRequest<PagingResultDto<MaterialDto>>
    {

    }
}
