using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Data.Unit.Tests
{
    public interface ILocalizedQuery<TResult>:IQuery<TResult>,IHaveLanguageId
    {
    }
}