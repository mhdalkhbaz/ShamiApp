using Application.Common;
using Application.Features.CategoryFeatures.Dtos;
using Application.Features.UnitMaterialFeatures.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialFeatures.Dtos
{
    public class MaterialDto : EntityDto<int>
    {
        public string Name { get; set; }
        public CategoryDto Category { get; set; }
        public UnitMaterialDto UnitMaterial { get; set; }
    }
}
