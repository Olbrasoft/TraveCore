using Olbrasoft.Travel.Data.Entity;

namespace Olbrasoft.Travel.Data.Repository.Property
{
    public interface INamesRepository<TEntity> : IOfName<TEntity> where TEntity : class, IHaveName
    {

    }
}