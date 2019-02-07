using Olbrasoft.Data.Querying;

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