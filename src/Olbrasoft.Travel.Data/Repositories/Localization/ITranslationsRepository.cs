using Olbrasoft.Travel.Data.Base.Objects.Localization;

namespace Olbrasoft.Travel.Data.Repositories.Localization
{
    public interface ITranslationsRepository<T> : ITravelRepository<T, int, int>, Olbrasoft.Data.Repository.Bulk.IRepository<T>
        where T : Translation
    {
        //bool Exists(int languageId);
        //IEnumerable<int> FindIds(int languageId);
    }
}