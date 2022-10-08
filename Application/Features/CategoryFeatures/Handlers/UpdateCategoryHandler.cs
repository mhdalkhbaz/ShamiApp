using Application.Features.CategoryFeatures.Dtos;
using Application.Features.CategoryFeatures.Commands;
using MediatR;
using Domain.Material;
using AutoMapper;

namespace Application.Features.CategoryFeatures.Handlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly  ICategoryService _categoryService;
        public UpdateCategoryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryService.UpdateAsync(request.UpdateCategoryDto);
            return Unit.Value;
        }
    }
}
