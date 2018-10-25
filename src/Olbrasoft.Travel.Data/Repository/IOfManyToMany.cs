using Olbrasoft.Travel.Data.Entity;

namespace Olbrasoft.Travel.Data.Repository
{
    public interface IOfManyToMany<T> : Olbrasoft.Data.Repository.Bulk.IRepository<T>, IBaseRepository<T, int, int> where T : ManyToMany
    {

    }
}