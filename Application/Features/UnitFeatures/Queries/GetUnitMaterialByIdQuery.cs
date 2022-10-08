using Application.Features.UnitMaterialFeatures.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitMaterialFeatures.Queries
{
    public class GetUnitMaterialByIdQuery : IRequest<UnitMaterialDto>
    {
        public int Id { get; set; }

        public GetUnitMaterialByIdQuery(int id)
        {
            Id = id;
        }
    }
}
