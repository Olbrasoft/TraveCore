using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.Travel.Data.Entity.Framework.Query.Handler
{
    public abstract class TravelQueryHandler<TContext, TQuery, TSource, TResult> : QueryHandler<TQuery, TSource, TResult>
        where TQuery : IQuery<TResult> where TContext :ITravelContext
    {
       
        protected TContext Context { get; }

        protected TravelQueryHandler( TContext context, IProjection projector) : base(projector)
        {
            Context = context;
        }
    }
}