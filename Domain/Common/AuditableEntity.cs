namespace Domain.Common
{
    public abstract class AuditableEntity<TId> : BaseEntity<TId>, IAuditableEntity<TId>
    {
        public string CreatedBy { get; set; } = "No body";
        public DateTime CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        protected AuditableEntity()
        {
            CreatedOn = DateTime.UtcNow;
            LastModifiedOn = DateTime.UtcNow;
        }
    }
}