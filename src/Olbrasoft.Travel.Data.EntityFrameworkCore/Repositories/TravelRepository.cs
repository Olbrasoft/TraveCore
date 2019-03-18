using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Repositories;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories
{
    #region TravelRepository<T, TKey, TKey2>
    public abstract class TravelRepository<T, TKey, TKey2> : SharpRepository.EfCoreRepository.EfCoreRepository<T, TKey, TKey2>, ITravelRepository<T, TKey, TKey2> where T : class
    {
        public event EventHandler Saved;

        protected TravelRepository(DbContext context) : base(context)
        {
        }

        public new void Add(IEnumerable<T> entities)
        {
            base.Add(entities);
            OnSaved(EventArgs.Empty);
        }

        public new void Add(T entity)
        {
            base.Add(entity);
            OnSaved(EventArgs.Empty);
        }

        public abstract void BulkSave(IEnumerable<T> entities, params Expression<Func<T, object>>[] ignorePropertiesWhenUpdating);

        protected void BulkInsert(IEnumerable<T> entities, int batchSize)
        {
            Context.BulkInsert(entities, OnSaved, batchSize);
        }

        protected void BulkInsert(IEnumerable<T> entities)
        {
            BulkInsert(entities, 90000);
        }

        protected void OnSaved(EventArgs eventArgs)
        {
            var handler = Saved;
            handler?.Invoke(this, eventArgs);
            ClearCache();
        }

        public abstract void ClearCache();
    }

    #endregion TravelRepository<T, TKey, TKey2>


    public class TravelRepository<T> : SharpRepository.EfCoreRepository.EfCoreRepository<T>, ITravelRepository<T> where T : class
    {
        public event EventHandler Saved;

        private bool _existMustBeRefreshed = true;
        private bool _exist;

        protected TravelRepository(DbContext context) : base(context)
        {
        }

        public new TResult Min<TResult>(Expression<Func<T, TResult>> selector)
        {
            return Context.Set<T>().Min(selector);
        }

        public new IEnumerable<TResult> GetAll<TResult>(Expression<Func<T, TResult>> selector)
        {
            return AsQueryable().Select(selector);
        }

        public bool Exists(bool clearRepositoryCache = false)
        {
            if (_existMustBeRefreshed || clearRepositoryCache)
            {
                _exist = AsQueryable().Any();
            }
            return _exist;
        }

        public T Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includePaths)
        {
            var query = Context.Set<T>().Where(predicate);

            if (includePaths != null)
            {
                query = includePaths.Aggregate(query,
                    (current, include) => current.Include(include));
            }

            return query.AsNoTracking().FirstOrDefault();
        }

        public new void Add(T entity)
        {
            base.Add(entity);
            OnSaved(EventArgs.Empty);

        }

        public new void Add(IEnumerable<T> entities)
        {
            base.Add(entities);
            OnSaved(EventArgs.Empty);
        }

        protected virtual void BulkInsert(IEnumerable<T> entities)
        {
            Context.BulkInsert(entities, OnSaved);
        }

        protected virtual void BulkInsert(IEnumerable<T> entities, int batchSize)
        {
            Context.BulkInsert(entities, OnSaved, batchSize);
        }

        protected void BulkUpdate(IEnumerable<T> entities, int batchSize, params Expression<Func<T, object>>[] ignorePropertiesWhenUpdating)
        {
            Context.BulkUpdate(entities, OnSaved, batchSize, ignorePropertiesWhenUpdating);
        }

        protected void OnSaved(EventArgs eventArgs)
        {
            var handler = Saved;
            handler?.Invoke(this, eventArgs);
            ClearCache();
        }

        public new virtual void ClearCache()
        {
            _existMustBeRefreshed = true;
            base.ClearCache();
        }

        //public static IEnumerable<List<T>> SplitToEnumerableOfList(IEnumerable<T> locations, int nSize = 30)
        //{
        //    var result = locations.ToList();
        //    for (var i = 0; i < result.Count; i += nSize)
        //    {
        //        yield return result.GetRange(i, Math.Min(nSize, result.Count - i));
        //    }
        //}
    }
}