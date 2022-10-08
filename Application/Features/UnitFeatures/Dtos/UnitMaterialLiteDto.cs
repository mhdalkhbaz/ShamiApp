using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitMaterialFeatures.Dtos
{ 
    public class UnitMaterialLiteDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
