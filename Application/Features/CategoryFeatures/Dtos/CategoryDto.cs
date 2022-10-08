using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Dtos
{
    public class CategoryDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
