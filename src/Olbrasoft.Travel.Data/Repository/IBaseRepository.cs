using SharpRepository.Repository;
using System;
using System.Linq.Expressions;

namespace Olbrasoft.Travel.Data.Repository
{
    public interface IBaseRepository<T> : IRepository<T> where T : class
    {
        bool Exists(bool clearRepositoryCache = false);

        T Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includePaths);
    }

    public interface IBaseRepository<T, TKey, TKey2> : ICompoundKeyRepository<T, TKey, TKey2>, ICanClearCache
        where T : class
    {
    }
}