using Olbrasoft.Data.Query;

namespace Olbrasoft.Business
{
    public abstract class Facade
    {
        protected IProvider QueryProvider { get; }

        protected Facade(IProvider queryProvider)
        {
            QueryProvider = queryProvider;
        }
    }
}