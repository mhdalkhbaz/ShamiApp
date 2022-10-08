using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Material
{
    public class UnitMaterial : AuditableEntity<int>
    {
        public string Name { get; set; }
        public List<Material> Materials { get; set; }
    }

}
