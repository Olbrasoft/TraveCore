using System.Collections.Generic;
using System.Linq;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Repository.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Framework.Repository.Globalization
{
    public class LanguagesRepository : GlobalizationRepository<Language>, ILanguagesRepository
    {
        private IReadOnlyDictionary<string, int> _eanLanguageCodesToIds;

        public IReadOnlyDictionary<string, int> EanLanguageCodesToIds
        {
            get
            {
                return _eanLanguageCodesToIds ?? (_eanLanguageCodesToIds = AsQueryable()
                           .Select(l => new { l.EanLanguageCode, l.Id }).ToDictionary(k => k.EanLanguageCode, v => v.Id));
            }

            private set => _eanLanguageCodesToIds = value;
        }

        public LanguagesRepository(GlobalizationDatabaseContext context) : base(context)
        {
        }

        public override void ClearCache()
        {
            EanLanguageCodesToIds = null;
            base.ClearCache();
        }
    }
}