using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    public class AwesomeQueryHandler : QueryHandler<AwesomeQuery, object, object>
    {
        public object TestContext => base.Context;

        public AwesomeQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }

        public override Task<object> HandleAsync(AwesomeQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}