using System;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    public class AwesomeTravelQueryHandler :TravelQueryHandler<AwesomeQuery,object,object>
    {
        public object TestContext => base.Context;

        public AwesomeTravelQueryHandler(TravelDbContext context , IProjection projector) : base(context, projector)
        {
        }

        public override Task<object> HandleAsync(AwesomeQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}