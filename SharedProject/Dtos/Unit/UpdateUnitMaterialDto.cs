using SharedProject.Dtos.Common;

namespace SharedProject.Dtos
{
    public class UpdateUnitMaterialDto : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
