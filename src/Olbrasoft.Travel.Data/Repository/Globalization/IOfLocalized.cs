using Olbrasoft.Travel.Data.Entity;

namespace Olbrasoft.Travel.Data.Repository.Globalization
{
    public interface IOfLocalized<T> :  IBaseRepository<T, int, int>, Olbrasoft.Data.Repository.Bulk.IRepository<T>
        where T : Localized
    {
        //bool Exists(int languageId);
        //IEnumerable<int> FindIds(int languageId);
    }
}