using Application.Features.CategoryFeatures.Dtos;
using Application.Features.CategoryFeatures.Commands;
using MediatR;
using Domain.Material;
using AutoMapper;

namespace Application.Features.CategoryFeatures.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly  ICategoryService _categoryService;
        public CreateCategoryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _categoryService.CreateAsync(request.CreateCategoryDto);
            return entity ;
        }
     
    }
}
