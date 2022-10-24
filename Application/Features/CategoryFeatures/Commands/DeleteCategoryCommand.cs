using MediatR;
using Application.Features.CategoryFeatures.Dtos;

namespace Application.Features.CategoryFeatures.Commands
{
    public class DeleteCategoryCommand : IRequest
    {
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
