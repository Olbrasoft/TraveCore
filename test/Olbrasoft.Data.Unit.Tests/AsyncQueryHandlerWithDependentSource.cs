﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Mapping;
using Olbrasoft.Querying;

namespace Olbrasoft.Data.Unit.Tests
{
    public abstract class AsyncQueryHandlerWithDependentSource<TQuery, TSource, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        protected IQueryable<TSource> Source { get; }
        protected IProjection Projector { get; }
        
        protected AsyncQueryHandlerWithDependentSource(IHaveQueryable<TSource> ownerQueryable, IProjection projector)
        {
            Source = ownerQueryable.Queryable;
            Projector = projector;
        }

        protected IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source)
        {
            return Projector.ProjectTo<TDestination>(source);
        }

        public TResult Handle(TQuery query)
        {
            return HandleAsync(query).Result;
        }

        public Task<TResult> HandleAsync(TQuery query)
        {
            return HandleAsync(query, default(CancellationToken));
        }

        public abstract Task<TResult> HandleAsync(TQuery query, CancellationToken token);
    }
}