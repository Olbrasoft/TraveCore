using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Repository.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Olbrasoft.Travel.Data.Entity.Framework.Repository.Globalization
{
    public class DescriptionsOfAccommodationsRepository : SharpRepository.EfCoreRepository.EfCoreRepository<LocalizedDescriptionOfAccommodation, int, int, int>, IDescriptionsOfAccommodationsRepository
    {
        protected new IGlobalizationContext Context { get; }

        public event EventHandler Saved;

        private HashSet<Tuple<int, int, int>> _keys;

        protected HashSet<Tuple<int, int, int>> Keys
        {
            get
            {
                return _keys ?? (_keys = new HashSet<Tuple<int, int, int>>(AsQueryable().Select(d => new { d.AccommodationId, d.TypeOfDescriptionId, d.LanguageId }).ToArray().Select(k =>
                               new Tuple<int, int, int>(k.AccommodationId, k.TypeOfDescriptionId, k.LanguageId))));
            }

            private set => _keys = value;
        }

        public DescriptionsOfAccommodationsRepository(GlobalizationDatabaseContext context) : base(context)
        {
            Context = context;
        }

        public void BulkSave(IEnumerable<LocalizedDescriptionOfAccommodation> descriptions, int batchSize, params Expression<Func<LocalizedDescriptionOfAccommodation, object>>[] ignorePropertiesWhenUpdating)
        {
            var forInsert = new Queue<LocalizedDescriptionOfAccommodation>();
            var forUpdate = new Queue<LocalizedDescriptionOfAccommodation>();

            foreach (var description in descriptions)
            {
                if (Keys.Contains(new Tuple<int, int, int>(description.AccommodationId, description.TypeOfDescriptionId,
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
                base.Context.BulkInsert(forInsert, OnSaved, batchSize);
            }

            if (forUpdate.Count > 0)
            {
                base.Context.BulkUpdate(forUpdate, OnSaved, batchSize, ignorePropertiesWhenUpdating);
            }
        }

        public void BulkSave(IEnumerable<LocalizedDescriptionOfAccommodation> descriptions, params Expression<Func<LocalizedDescriptionOfAccommodation, object>>[] ignorePropertiesWhenUpdating)
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