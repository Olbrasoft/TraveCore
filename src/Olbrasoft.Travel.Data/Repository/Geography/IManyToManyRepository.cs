using Olbrasoft.Travel.Data.Entity;

namespace Olbrasoft.Travel.Data.Repository.Geography
{
    public interface IManyToManyRepository<TEntity> : IOfManyToMany<TEntity> where TEntity : ManyToMany
    {
    }
}