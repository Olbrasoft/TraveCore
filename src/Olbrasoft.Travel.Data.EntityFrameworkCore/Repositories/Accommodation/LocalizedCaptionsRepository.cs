using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Localization;
using Olbrasoft.Travel.Data.Repositories.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Accommodation
{
    public class LocalizedCaptionsRepository : LocalizedRepository<CaptionTranslation>, ILocalizedCaptionsRepository
    {
        private int _maxCaptionId;

        protected int MaxCaptionId
        {
            get
            {
                if (_maxCaptionId != 0) return _maxCaptionId;

                var captions = Context.Set<Caption>();
                _maxCaptionId = captions.Any() ? captions.Max(c => c.Id) : 0;

                return _maxCaptionId;
            }

            private set => _maxCaptionId = value;
        }

        public override void BulkSave(IEnumerable<CaptionTranslation> localizedCaptions,
            params Expression<Func<CaptionTranslation, object>>[] ignorePropertiesWhenUpdating)
        {
            var localizedCaptionsForInsert = BuildLocalizedCaptionsForInsert(localizedCaptions);

            if (!localizedCaptionsForInsert.Any()) return;

            Context.BulkInsert(localizedCaptionsForInsert.Select(lc => lc.Caption), OnSaved);
            Context.BulkInsert(localizedCaptionsForInsert, OnSaved);
        }

        private CaptionTranslation[] BuildLocalizedCaptionsForInsert(
            IEnumerable<CaptionTranslation> localizedCaptions)
        {
            var localizedCaptionsForInsert = new Queue<CaptionTranslation>();
            var localizedCaptionsArray = localizedCaptions as CaptionTranslation[] ?? localizedCaptions.ToArray();

            foreach (var languageId in localizedCaptionsArray.GroupBy(entity => entity.LanguageId).Select(grp => grp.First())
                .Select(p => p.LanguageId))
            {
                foreach (var localizedCaption in localizedCaptionsArray.Where(lc => lc.LanguageId == languageId && lc.Id == 0 && lc.Caption == null))
                {
                    if (GetLocalizedCaptionsTexts(languageId).Contains(localizedCaption.Text)) continue;

                    MaxCaptionId++;

                    localizedCaptionsForInsert.Enqueue(RebuildLocalizedCaption(localizedCaption, MaxCaptionId));
                }
            }

            return localizedCaptionsForInsert.ToArray();
        }

        private static CaptionTranslation RebuildLocalizedCaption(CaptionTranslation captionTranslation, int id)
        {
            var caption = new Caption
            {
                Id = id,
                CreatorId = captionTranslation.CreatorId
            };

            captionTranslation.Caption = caption;
            captionTranslation.Id = id;

            return captionTranslation;
        }

        protected HashSet<string> GetLocalizedCaptionsTexts(int languageId)
        {
            return new HashSet<string>(AsQueryable().Where(lc => lc.LanguageId == languageId).Select(lc => lc.Text));
        }

        public override void ClearCache()
        {
            MaxCaptionId = 0;
            base.ClearCache();
        }

        public IReadOnlyDictionary<string, int> GetLocalizedCaptionsTextsToIds(int languageId)
        {
            return AsQueryable().Where(lc => lc.LanguageId == languageId).Select(lc => new { lc.Text, lc.Id })
                .ToDictionary(k => k.Text, v => v.Id);
        }

        public LocalizedCaptionsRepository(DbContext context) : base(context)
        {
        }
    }
}