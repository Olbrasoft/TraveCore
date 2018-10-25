using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Repository.Globalization
{
    public interface ILanguagesRepository : IBaseRepository<Language>
    {
        IReadOnlyDictionary<string, int> EanLanguageCodesToIds { get; }
    }
}