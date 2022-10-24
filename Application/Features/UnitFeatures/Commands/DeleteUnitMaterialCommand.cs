using MediatR;

namespace Application.Features.UnitMaterialFeatures.Commands
{
    public class DeleteUnitMaterialCommand : IRequest
    {
        public DeleteUnitMaterialCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
