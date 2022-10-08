using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaterialFeatures.Dtos
{
    public class MaterialLiteDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
