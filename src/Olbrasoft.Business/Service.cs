using Olbrasoft.Data.Query;

namespace Olbrasoft.Business
{
    public abstract class Service
    {
        protected IProvider QueryProvider { get; }

        protected Service(IProvider queryProvider)
        {
            QueryProvider = queryProvider;
        }
    }
}