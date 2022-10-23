using MediatR;
using Application.Features.CategoryFeatures.Dtos;

namespace Application.Features.CategoryFeatures.Commands
{
    public class UpdateCategoryCommand : IRequest
    {
        public UpdateCategoryCommand(UpdateCategoryDto updateCategoryDto)
        {
            UpdateCategoryDto = updateCategoryDto;
        }

        public UpdateCategoryDto UpdateCategoryDto { get; set; }

    }
}
