using Application.Common;
using Application.Features.CategoryFeatures.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialFeatures.Dtos
{
    public class UpdateMaterialDto : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId  { get; set; }
        public int UnitMaterialId  { get; set; }
    }
}
