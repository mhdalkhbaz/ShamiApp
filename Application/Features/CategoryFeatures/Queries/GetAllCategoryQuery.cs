using Application.Common.Dtos;
using Application.Features.CategoryFeatures.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Queries
{
    public class GetAllCategoryQuery : IRequest<PagingResultDto<CategoryDto>>
    {

    }
}
