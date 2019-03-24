namespace Olbrasoft.Data
{
    public interface IHaveLabel<out T>
    {
        T Label { get; }
    }

    public interface IHaveLabel : IHaveLabel<string>
    {
    }
}