using SharedProject.Dtos.Common;

namespace SharedProject.Dtos
{
    public class UpdateMaterialDto : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId  { get; set; }
        public int UnitMaterialId  { get; set; }
    }
}
