using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Entity.Framework.Bulk;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Repositories.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Geography
{
    public class RegionsRepository : TravelRepository<Region>, IRegionsRepository
    {
        private long _minExpediaId = long.MinValue;

        private IReadOnlyDictionary<long, int> _expediaIdsToIds;

        public IReadOnlyDictionary<long, int> ExpediaIdsToIds
        {
            get
            {
                return _expediaIdsToIds ?? (_expediaIdsToIds = AsQueryable().Where(p => p.ExpediaId >= 0)
                           .Select(r => new { r.ExpediaId, r.Id })
                           .ToDictionary(k => k.ExpediaId, v => v.Id));

                //return _ExpediaIdsToIds ?? (_ExpediaIdsToIds =
                //           FindAll(p => p.ExpediaId >= 0, s => new { EanRegionId = s.ExpediaId, s.Id })
                //               .ToDictionary(k => k.EanRegionId, v => v.Id));
            }

            private set => _expediaIdsToIds = value;
        }

        //public Task BulkUpdateAsync(IEnumerable<Region> regions, params Expression<Func<Region, object>>[] ignorePropertiesWhenUpdating)
        //{
        //    if (regions == null) throw new ArgumentNullException(nameof(regions));

        //    var ignoreColumnsUpdate = new HashSet<string>(ignorePropertiesWhenUpdating.Select(DbContextExtensions.GetPropertyName));
        //    const string creatorIdColumnName = "CreatorId";

        //    if (!ignoreColumnsUpdate.Contains(creatorIdColumnName)) ignoreColumnsUpdate.Add(creatorIdColumnName);

        //    return Context.BulkUpdateAsync(regions.ToList(), new BulkConfig
        //    {
        //        BatchSize = 45000,
        //        BulkCopyTimeout = 960,
        //        IgnoreColumns = new HashSet<string>(new[] { "Created" }),
        //        IgnoreColumnsUpdate = ignoreColumnsUpdate
        //    });

        //    //var batchesToUpdate = regions.SplitToEnumerableOfList(90000);
        //    //var tasks = batchesToUpdate.Select(batch => Context.BulkUpdateAsync(batch, new BulkConfig { BatchSize = 45000, BulkCopyTimeout = 480, IgnoreColumns = new HashSet<string>(new[] { "Created" }), IgnoreColumnsUpdate = ignoreColumnsUpdate }));
        //    //return Task.WhenAll(tasks.ToArray());
        //}

        //public async Task<Dictionary<long, int>> BulkSaveAsync(IEnumerable<Region> regions,
        //    params Expression<Func<Region, object>>[] ignorePropertiesWhenUpdating)
        //{
        //    if (regions == null) throw new ArgumentNullException(nameof(regions));

        //    regions = Rebuild(regions.ToArray());

        //    var regionsToUpdate = regions.Where(region => region.Id != 0).ToArray();

        //    if (regionsToUpdate.Any())
        //    {
        //        await BulkUpdateAsync(regionsToUpdate, ignorePropertiesWhenUpdating);
        //        ClearCache();
        //    }

        //    return await Context.Set<Region>().Where(p => p.ExpediaId >= 0).Select(r => new { r.ExpediaId, r.Id })
        //        .ToDictionaryAsync(k => k.ExpediaId, v => v.Id);
        //}

        private long MinExpediaId
        {
            get
            {
                if (_minExpediaId != long.MinValue) return _minExpediaId;

                if (Exists(region => region.ExpediaId < 0))
                {
                    _minExpediaId = Min(region => region.ExpediaId) - 1;
                }
                else
                {
                    _minExpediaId = -1;
                }

                return _minExpediaId;
            }

            set => _minExpediaId = value;
        }

        public RegionsRepository(DbContext context) : base(context)
        {
        }

        public new void Add(Region region)
        {
            region = Rebuild(new[] { region }).FirstOrDefault();

            base.Add(region);
        }

        public void BulkSave(IEnumerable<Region> regions, int batchSize, params Expression<Func<Region, object>>[] ignorePropertiesWhenUpdating)
        {
            if (regions == null) throw new ArgumentNullException(nameof(regions));

            regions = Rebuild(regions.ToArray());

            if (regions.Any(region => region.Id == 0))
            {
                BulkInsert(regions.Where(region => region.Id == 0), batchSize);
            }

            if (regions.Any(region => region.Id != 0))
            {
                BulkUpdate(regions.Where(region => region.Id != 0), batchSize, ignorePropertiesWhenUpdating);
            }
        }

        public void BulkSave(IEnumerable<Region> regions, params Expression<Func<Region, object>>[] ignorePropertiesWhenUpdating)
        {
            BulkSave(regions, 90000, ignorePropertiesWhenUpdating);
        }

        protected Region[] Rebuild(Region[] regions)
        {
            regions = AddingIdsOnDependingRegionIds(regions);
            regions = OverrideRegionIds(regions);

            return regions;
        }

        protected Region[] AddingIdsOnDependingRegionIds(Region[] regions)
        {
            foreach (var region in regions.Where(p => p.ExpediaId >= 0 && p.Id == 0))
            {
                if (!ExpediaIdsToIds.TryGetValue(region.ExpediaId, out var id)) continue;
                region.Id = id;
            }
            return regions;
        }

        protected Region[] OverrideRegionIds(Region[] regions)
        {
            if (regions.All(r => r.ExpediaId != long.MinValue)) return regions;

            foreach (var region in regions.Where(p => p.ExpediaId == long.MinValue))
            {
                region.ExpediaId = MinExpediaId;
                MinExpediaId -= 1;
            }

            return regions;
        }

        public override void ClearCache()
        {
            MinExpediaId = long.MinValue;
            ExpediaIdsToIds = null;
            base.ClearCache();
        }
    }
}