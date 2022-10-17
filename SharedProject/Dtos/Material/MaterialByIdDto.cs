using SharedProject.Dtos.Common;

namespace SharedProject.Dtos
{
    public class MaterialByIdDto : EntityDto<int> 
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int UnitMaterialId { get; set; }
    }
}
