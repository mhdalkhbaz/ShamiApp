namespace Application.Common
{
    public class EntityDto<TKey> : IEntityDto<TKey>
    {
        public TKey Id { get; set; }
    }
}
