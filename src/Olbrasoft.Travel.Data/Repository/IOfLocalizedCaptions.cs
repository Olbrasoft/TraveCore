using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Repository.Globalization;

namespace Olbrasoft.Travel.Data.Repository
{
    public interface IOfLocalizedCaptions : IOfLocalized<LocalizedCaption>
    {
        IReadOnlyDictionary<string, int> GetLocalizedCaptionsTextsToIds(int languageId);
    }
}