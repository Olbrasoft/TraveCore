using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Localization;
using Olbrasoft.Travel.Data.Repositories.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Localization
{
    public class LanguagesRepository : TravelRepository<Language>, ILanguagesRepository
    {
        private IReadOnlyDictionary<string, int> _eanLanguageCodesToIds;

        public IReadOnlyDictionary<string, int> EanLanguageCodesToIds
        {
            get
            {
                return _eanLanguageCodesToIds ?? (_eanLanguageCodesToIds = AsQueryable()
                           .Select(l => new { EanLanguageCode = l.ExpediaCode, l.Id }).ToDictionary(k => k.EanLanguageCode, v => v.Id));
            }

            private set => _eanLanguageCodesToIds = value;
        }

        public LanguagesRepository(DbContext context) : base(context)
        {
        }

        public override void ClearCache()
        {
            EanLanguageCodesToIds = null;
            base.ClearCache();
        }
    }
}