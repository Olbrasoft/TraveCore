using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Entity;


namespace Olbrasoft.Data.Unit.Tests
{
    public interface ILocalizedQuery<TResult>:IQuery<TResult>,ILocalized
    {
    }
}