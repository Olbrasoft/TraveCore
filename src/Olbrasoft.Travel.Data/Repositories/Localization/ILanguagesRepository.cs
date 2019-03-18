using System.Collections.Generic;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.Repositories.Localization
{
    public interface ILanguagesRepository : ITravelRepository<Language>
    {
        IReadOnlyDictionary<string, int> EanLanguageCodesToIds { get; }
    }
}