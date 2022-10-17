using SharedProject.Dtos;
using SharedProject.Dtos.Common;

namespace SharedProject.Dtos
{
    public class MaterialDto : EntityDto<int>
    {
        public string Name { get; set; }
        public CategoryDto Category { get; set; }
        public UnitMaterialDto UnitMaterial { get; set; }
    }
}
