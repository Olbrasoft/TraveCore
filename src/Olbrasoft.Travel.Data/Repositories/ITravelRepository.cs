using System;
using System.Linq.Expressions;
using SharpRepository.Repository;

namespace Olbrasoft.Travel.Data.Repositories
{
    public interface ITravelRepository<T> : IRepository<T> where T : class
    {
        bool Exists(bool clearRepositoryCache = false);

        T Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includePaths);
    }

    public interface ITravelRepository<T, TKey, TKey2> : ICompoundKeyRepository<T, TKey, TKey2>, ICanClearCache
        where T : class
    {
    }



}