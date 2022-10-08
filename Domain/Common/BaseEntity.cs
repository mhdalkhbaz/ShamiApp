namespace Domain.Common
{
    public class BaseEntity<TId> : IBaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}