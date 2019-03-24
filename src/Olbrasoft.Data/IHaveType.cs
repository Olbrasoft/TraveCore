namespace Olbrasoft.Data
{
    public interface IHaveType<out T>
    {
        T Type { get; }
    }
}