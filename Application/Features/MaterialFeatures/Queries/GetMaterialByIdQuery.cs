using Application.Features.MaterialFeatures.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialFeatures.Queries
{
    public class GetMaterialByIdQuery : IRequest<MaterialDto>
    {
        public int Id { get; set; }

        public GetMaterialByIdQuery(int id)
        {
            Id = id;
        }
    }
}
