namespace SharedProject.Dtos.Common
{
    public interface IEntityDto<TKey>
    {
        public TKey Id { get; set; }
    }
}
