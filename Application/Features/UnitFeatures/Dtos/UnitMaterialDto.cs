using Application.Common;
using Domain.Common;
using Domain.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitMaterialFeatures.Dtos
{
    public class UnitMaterialDto  : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
