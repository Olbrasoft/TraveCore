using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Repositories.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Accommodation
{
    public class DescriptionsRepository : SharpRepository.EfCoreRepository.EfCoreRepository<DescriptionTranslation, int, int, int>, IDescriptionsRepository
    {
        public event EventHandler Saved;

        private HashSet<Tuple<int, int, int>> _keys;

        protected HashSet<Tuple<int, int, int>> Keys
        {
            get
            {
                return _keys ?? (_keys = new HashSet<Tuple<int, int, int>>(AsQueryable().Select(d => new { AccommodationId = d.PropertyId, TypeOfDescriptionId = d.DescriptionId, d.LanguageId }).ToArray().Select(k =>
                               new Tuple<int, int, int>(k.AccommodationId, k.TypeOfDescriptionId, k.LanguageId))));
            }

            private set => _keys = value;
        }

        public DescriptionsRepository(DbContext context) : base(context)
        {
        }

        public void BulkSave(IEnumerable<DescriptionTranslation> descriptions, int batchSize, params Expression<Func<DescriptionTranslation, object>>[] ignorePropertiesWhenUpdating)
        {
            var forInsert = new Queue<DescriptionTranslation>();
            var forUpdate = new Queue<DescriptionTranslation>();

            foreach (var description in descriptions)
            {
                if (Keys.Contains(new Tuple<int, int, int>(description.PropertyId, description.DescriptionId,
                    description.LanguageId)))
                {
                    forUpdate.Enqueue(description);
                }
                else
                {
                    forInsert.Enqueue(description);
                }
            }

            if (forInsert.Count > 0)
            {
                Context.BulkInsert(forInsert, OnSaved, batchSize);
            }

            if (forUpdate.Count > 0)
            {
                Context.BulkUpdate(forUpdate, OnSaved, batchSize, ignorePropertiesWhenUpdating);
            }
        }

        public void BulkSave(IEnumerable<DescriptionTranslation> descriptions, params Expression<Func<DescriptionTranslation, object>>[] ignorePropertiesWhenUpdating)
        {
            BulkSave(descriptions, 90000, ignorePropertiesWhenUpdating);
        }

        protected void OnSaved(EventArgs eventArgs)
        {
            var handler = Saved;
            handler?.Invoke(this, eventArgs);
            ClearCache();
        }

        public void ClearCache()
        {
            Keys = null;
        }
    }
}