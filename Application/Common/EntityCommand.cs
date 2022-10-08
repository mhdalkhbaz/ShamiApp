namespace Application.Common
{
    public class EntityCommand<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
