namespace FSHR.Models
{
    public interface IModel<TKey>
    {
        TKey Id { get; }
    }
}