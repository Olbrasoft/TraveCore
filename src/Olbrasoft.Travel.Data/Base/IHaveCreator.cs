namespace Olbrasoft.Travel.Data.Base
{
    public interface IHaveCreator<out T> where T : ICreator
    {
        T Creator { get; }
    }
}