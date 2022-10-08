using MediatR;
using Application.Features.CategoryFeatures.Dtos;

namespace Application.Features.CategoryFeatures.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public CreateCategoryCommand(CreateCategoryDto createCategoryDto)
        {
            CreateCategoryDto = createCategoryDto;
        }

        public CreateCategoryDto CreateCategoryDto { get; set; }

    }
}
