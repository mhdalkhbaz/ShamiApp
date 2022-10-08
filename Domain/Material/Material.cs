using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Material
{
    public class Material : AuditableEntity<int>
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public int UnitMaterialId { get; set; }
        [ForeignKey(nameof(UnitMaterialId))]
        public UnitMaterial UnitMaterial { get; set; }

        public static string[] GetIncludeAll()
        {
            return new string[] { nameof(Category), nameof(UnitMaterial) };
        }
    }
}
