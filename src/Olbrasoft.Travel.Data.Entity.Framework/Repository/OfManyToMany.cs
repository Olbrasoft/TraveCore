using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Repository;

namespace Olbrasoft.Travel.Data.Entity.Framework.Repository
{
    public class OfManyToMany<T> : BaseRepository<T, int, int>, IOfManyToMany<T> where T : ManyToMany
    {
        private HashSet<Tuple<int, int>> _idsToToIds;

        public HashSet<Tuple<int, int>> IdsToToIds
        {
            get
            {
                if (_idsToToIds != null) return _idsToToIds;

                _idsToToIds = new HashSet<Tuple<int, int>>(AsQueryable().Select(p => new { p.Id, p.ToId }).ToArray()
                    .Select(p => new Tuple<int, int>(p.Id, p.ToId)));

                return _idsToToIds;
            }

            private set => _idsToToIds = value;
        }

      

        public void BulkSave(IEnumerable<T> manyToManyEntities, int batchSize, params Expression<Func<T, object>>[] ignorePropertiesWhenUpdating)
        {
            var forInsert = new Dictionary<Tuple<int, int>, T>();

            foreach (var manyToMany in manyToManyEntities)
            {
                var tup = new Tuple<int, int>(manyToMany.Id, manyToMany.ToId);

                if (IdsToToIds.Contains(tup)) continue;

                if (!forInsert.ContainsKey(tup))
                {
                    forInsert.Add(tup, manyToMany);
                }
            }

            BulkInsert(forInsert.Values);
        }

        public override void BulkSave(IEnumerable<T> manyToManyEntities, params Expression<Func<T, object>>[] ignorePropertiesWhenUpdating)
        {
            BulkSave(manyToManyEntities, 90000, ignorePropertiesWhenUpdating);
        }

        public override void ClearCache()
        {
            IdsToToIds = null;
        }

        public OfManyToMany(DbContext context) : base(context)
        {
        }
    }
}