using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.Data.Unit.Tests.Querying
{
    public class QueryHandlerTest
    {
        [Test]
        public void Instance_Implement_Interface_IQueryHandler()
        {
            //Arrange
            var type = typeof(IQueryHandler<AwesomeQuery,object>);

            //Act
            var handler = new AwesomeQueryHandler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void QueryHandler_Is_Abstract()
        {
            //Arrange
            var type = typeof(QueryHandler<AwesomeQuery, object>);

            //Act
            var result = type.IsAbstract;
            
            //Assert
            Assert.IsTrue(result);


        }

    }

    class AwesomeQueryHandler : QueryHandler<AwesomeQuery, object>
    {
        public override Task<object> HandleAsync(AwesomeQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }


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
