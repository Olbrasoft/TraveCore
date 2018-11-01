using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Olbrasoft.Travel.Data.Entity.Framework.Repository.Globalization
{
    public class AccommodationsToAttributesRepository : SharpRepository.EfCoreRepository.EfCoreRepository<AccommodationToAttribute, int, int, int>, IAccommodationsToAttributesRepository
    {
        public event EventHandler Saved;

        protected new IGlobalizationContext Context { get; }

        public AccommodationsToAttributesRepository(GlobalizationDatabaseContext context) : base(context)
        {
            Context = context;
        }

        public void BulkSave(IEnumerable<AccommodationToAttribute> accommodationsToAttributes)
        {
            var accommodationsToAttributesArray = accommodationsToAttributes as AccommodationToAttribute[] ?? accommodationsToAttributes.ToArray();

            foreach (var languageId in accommodationsToAttributesArray.GroupBy(entity => entity.LanguageId).Select(grp => grp.First())
                .Select(p => p.LanguageId))
            {
                accommodationsToAttributesArray =
                    accommodationsToAttributesArray.Where(p => p.LanguageId == languageId).ToArray();

                if (!AsQueryable().Any(l => l.LanguageId == languageId))
                {
                    base.Context.BulkInsert(accommodationsToAttributesArray.Where(ata => ata.LanguageId == languageId), OnSaved, 2000000);
                }
                else
                {
                    var storedAccommodationsIdsAttributesIds = FindAccommodationsIdsAttributesIds(languageId);

                    var forInsert = new List<AccommodationToAttribute>();
                    var forUpdate = new List<AccommodationToAttribute>();

                    foreach (var accommodationToAttribute in accommodationsToAttributesArray)
                    {
                        var tup = new Tuple<int, int>(accommodationToAttribute.AccommodationId, accommodationToAttribute.AttributeId);

                        if (!storedAccommodationsIdsAttributesIds.Contains(tup))
                        {
                            forInsert.Add(accommodationToAttribute);
                        }
                        else
                        {
                            forUpdate.Add(accommodationToAttribute);
                        }
                    }

                    if (forInsert.Count > 0)
                    {
                        base.Context.BulkInsert(forInsert, OnSaved, 2000000);
                    }

                    if (forUpdate.Count <= 0) return;
                    base.Context.BulkUpdate(forUpdate, OnSaved, 2000000);
                }
            }
        }

        public HashSet<Tuple<int, int>> FindAccommodationsIdsAttributesIds(int languageId)
        {
            return new HashSet<Tuple<int, int>>(AsQueryable().Where(lr => lr.LanguageId == languageId)
                .Select(ata => new { ata.AccommodationId, ata.AttributeId }).ToArray()
                .Select(p => new Tuple<int, int>(p.AccommodationId, p.AttributeId)));
        }

        protected void OnSaved(EventArgs eventArgs)
        {
            var handler = Saved;
            handler?.Invoke(this, eventArgs);
        }
    }
}