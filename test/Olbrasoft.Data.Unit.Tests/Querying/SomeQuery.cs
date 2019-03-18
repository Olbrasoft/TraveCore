using System;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.Data.Unit.Tests.Querying
{
    public class SomeQuery : IQuery<SomeObject>
    {
        public SomeObject Execute()
        {
            throw new NotImplementedException();
        }

        public Task<SomeObject> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}