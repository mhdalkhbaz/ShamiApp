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
    public class GetPagingAsyncQuery : IRequest<PagingResultDto<CategoryDto>>
    {
        public PagingDto  PagingDto { get; set; }

        public GetPagingAsyncQuery(PagingDto pagingDto)
        {
            PagingDto = pagingDto;
        }
    }
}
