using Application.Common.Dtos;
using Application.Features.CategoryFeatures.Dtos;
using Application.Features.CategoryFeatures.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Handlers
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, PagingResultDto<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;
        public GetAllCategoryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<PagingResultDto<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _categoryService.GetPagingAsync(null);
        }
    }
}
