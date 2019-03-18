using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Repositories
{
    public interface IManyToManyRepository<T> : Olbrasoft.Data.Repository.Bulk.IRepository<T>, ITravelRepository<T, int, int> where T : ManyToMany
    {

    }
}