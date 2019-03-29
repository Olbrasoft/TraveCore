using System.Collections.Generic;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Repositories.Localization;

namespace Olbrasoft.Travel.Data.Repositories.Accommodation
{
    public interface ICaptionsTranslationsRepository : ITranslationsRepository<CaptionTranslation>
    {
        IReadOnlyDictionary<string, int> GetLocalizedCaptionsTextsToIds(int languageId);
    }
}