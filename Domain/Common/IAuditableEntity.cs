namespace Domain.Common
{
    public interface IAuditableEntity<TId> : IBaseEntity<TId>
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
