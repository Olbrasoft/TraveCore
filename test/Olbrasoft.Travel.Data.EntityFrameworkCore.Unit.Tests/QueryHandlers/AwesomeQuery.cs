using System;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Querying;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    public class AwesomeQuery : IQuery<object>
    {
     
     

        public object Execute()
        {
            throw new NotImplementedException();
        }

        public Task<object> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}