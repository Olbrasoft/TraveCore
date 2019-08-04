using System;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Mapping;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    public class AwesomeQueryHandler : TravelQueryHandler<AwesomeQuery, object, object>
    {
        public object TestContext => base.Context;

        public AwesomeQueryHandler(IProjection projector,TravelDbContext context) : base( projector,context)
        {
        }

        public override Task<object> HandleAsync(AwesomeQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}