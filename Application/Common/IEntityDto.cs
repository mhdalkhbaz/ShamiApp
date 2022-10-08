namespace Application.Common
{
    public interface IEntityDto<TKey>
    {
        public TKey Id { get; set; }
    }
}
