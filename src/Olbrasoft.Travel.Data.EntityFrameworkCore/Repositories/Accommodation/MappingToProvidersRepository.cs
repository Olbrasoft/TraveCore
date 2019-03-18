using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Repositories.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Accommodation
{
    public class MappingToProvidersRepository<T> : TravelRepository<T>, IMappingToProvidersRepository<T> where T : CreationInfo<int>, IHaveExpediaId<int>
    {
        private int _minExpediaId = int.MinValue;
        private HashSet<int> _ExpediaIds;
        private IReadOnlyDictionary<int, int> _ExpediaIdsToIds;

        public HashSet<int> ExpediaIds
        {
            get
            {
                return _ExpediaIds ?? (_ExpediaIds = _ExpediaIdsToIds != null
                           ? new HashSet<int>(_ExpediaIdsToIds.Keys)
                           : new HashSet<int>(AsQueryable().Where(p => p.ExpediaId >= 0).Select(p => p.ExpediaId)));
            }

            private set => _ExpediaIds = value;
        }

        public IReadOnlyDictionary<int, int> ExpediaIdsToIds
        {
            get => _ExpediaIdsToIds ?? (_ExpediaIdsToIds = AsQueryable().Where(toa => toa.ExpediaId >= 0)
                       .Select(toa => new { ExpediaId = toa.ExpediaId, toa.Id }).ToDictionary(k => k.ExpediaId, v => v.Id));

            private set => _ExpediaIdsToIds = value;
        }

        private int MinExpediaId
        {
            get
            {
                if (_minExpediaId != int.MinValue) return _minExpediaId;
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

        public MappingToProvidersRepository(DbContext context) : base(context)
        {
        }

        public void BulkSave(IEnumerable<T> entities, int batchSize, params Expression<Func<T, object>>[] ignorePropertiesWhenUpdating)
        {
            entities = Rebuild(entities.ToArray());

            if (entities.Any(region => region.Id == 0))
            {
                BulkInsert(entities.Where(region => region.Id == 0), batchSize);
            }

            if (entities.Any(region => region.Id != 0))
            {
                BulkUpdate(entities.Where(region => region.Id != 0), batchSize, ignorePropertiesWhenUpdating);
            }
        }

        public void BulkSave(IEnumerable<T> entities, params Expression<Func<T, object>>[] ignorePropertiesWhenUpdating)
        {
            BulkSave(entities, 90000, ignorePropertiesWhenUpdating);
        }

        protected T[] Rebuild(T[] entities)
        {
            entities = AddingIdsOnDependingExpediaIds(entities);
            entities = OverrideExpediaIds(entities);

            return entities;
        }

        protected T[] AddingIdsOnDependingExpediaIds(T[] entities)
        {
            foreach (var typeOfAccommodation in entities.Where(p => p.ExpediaId >= 0 && p.Id == 0))
            {
                if (!ExpediaIdsToIds.TryGetValue(typeOfAccommodation.ExpediaId, out var id)) continue;
                typeOfAccommodation.Id = id;
            }
            return entities;
        }

        protected T[] OverrideExpediaIds(T[] entities)
        {
            if (entities.All(r => r.ExpediaId != int.MinValue)) return entities;

            foreach (var region in entities.Where(p => p.ExpediaId == int.MinValue))
            {
                region.ExpediaId = MinExpediaId;
                MinExpediaId = MinExpediaId - 1;
            }

            return entities;
        }

        public override void ClearCache()
        {
            MinExpediaId = int.MinValue;
            ExpediaIds = null;
            ExpediaIdsToIds = null;
            base.ClearCache();
        }
    }
}