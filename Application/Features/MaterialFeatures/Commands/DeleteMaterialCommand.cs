using MediatR;

namespace Application.Features.MaterialFeatures.Commands
{
    public class DeleteMaterialCommand : IRequest
    {
        public DeleteMaterialCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
