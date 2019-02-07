using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.Data.Unit.Tests
{
    internal class SomeHandlerWithDependentSource : HandlerWithDependentSource<SomQuery,object, object>
    {
    
        public SomeHandlerWithDependentSource(IHaveQueryable<object> source) : base(source,new Mock<IProjection>().Object)
        {
        }

        public override object Handle(SomQuery query)
        {
            return new object();
            throw new System.NotImplementedException();
        }

        public override Task<object> HandleAsync(SomQuery query, CancellationToken cancellationToken)
        {



            throw new System.NotImplementedException();
        }
    }
}