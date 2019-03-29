using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Repositories.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Accommodation
{
    public class PropertiesToAttributesRepository : SharpRepository.EfCoreRepository.EfCoreRepository<PropertyToAttribute, int, int, int>, IPropertiesToAttributesRepository
    {
        public event EventHandler Saved;

        public PropertiesToAttributesRepository(DbContext context) : base(context)
        {
        }

        public void BulkSave(IEnumerable<PropertyToAttribute> accommodationsToAttributes)
        {
            var accommodationsToAttributesArray = accommodationsToAttributes as PropertyToAttribute[] ?? accommodationsToAttributes.ToArray();

            foreach (var languageId in accommodationsToAttributesArray.GroupBy(entity => entity.LanguageId).Select(grp => grp.First())
                .Select(p => p.LanguageId))
            {
                accommodationsToAttributesArray =
                    accommodationsToAttributesArray.Where(p => p.LanguageId == languageId).ToArray();

                if (!AsQueryable().Any(l => l.LanguageId == languageId))
                {
                    Context.BulkInsert(accommodationsToAttributesArray.Where(ata => ata.LanguageId == languageId), OnSaved, 2000000);
                }
                else
                {
                    var storedAccommodationsIdsAttributesIds = FindAccommodationsIdsAttributesIds(languageId);

                    var forInsert = new List<PropertyToAttribute>();
                    var forUpdate = new List<PropertyToAttribute>();

                    foreach (var accommodationToAttribute in accommodationsToAttributesArray)
                    {
                        var tup = new Tuple<int, int>(accommodationToAttribute.RealEstateId, accommodationToAttribute.AttributeId);

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
                        Context.BulkInsert(forInsert, OnSaved, 2000000);
                    }

                    if (forUpdate.Count <= 0) return;
                    Context.BulkUpdate(forUpdate, OnSaved, 2000000);
                }
            }
        }

        public HashSet<Tuple<int, int>> FindAccommodationsIdsAttributesIds(int languageId)
        {
            return new HashSet<Tuple<int, int>>(AsQueryable().Where(lr => lr.LanguageId == languageId)
                .Select(ata => new { AccommodationId = ata.RealEstateId, ata.AttributeId }).ToArray()
                .Select(p => new Tuple<int, int>(p.AccommodationId, p.AttributeId)));
        }

        protected void OnSaved(EventArgs eventArgs)
        {
            var handler = Saved;
            handler?.Invoke(this, eventArgs);
        }
    }
}