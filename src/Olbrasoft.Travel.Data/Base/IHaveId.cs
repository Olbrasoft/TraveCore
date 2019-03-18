namespace Olbrasoft.Travel.Data.Base
{
    public interface IHaveId<T>
    {
        T Id { get; set; }
    }
}