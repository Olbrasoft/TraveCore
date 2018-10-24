namespace Olbrasoft.Travel.Data.Entity
{
    public interface IHaveId<T>
    {
        T Id { get; set; }
    }
}