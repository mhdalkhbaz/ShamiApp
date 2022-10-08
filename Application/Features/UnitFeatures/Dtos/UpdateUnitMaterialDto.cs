using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UnitMaterialFeatures.Dtos
{
    public class UpdateUnitMaterialDto : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
