using Olbrasoft.Data.Queries;

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