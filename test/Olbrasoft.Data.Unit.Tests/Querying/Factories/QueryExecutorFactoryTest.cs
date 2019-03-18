using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Data.Querying.Factories;
using Olbrasoft.Dependence;

namespace Olbrasoft.Data.Unit.Tests.Querying.Factories
{
    [TestFixture]
    internal class QueryExecutorFactoryTest
    {
        [Test]
        public void Instance_Implement_Interface_IQueryExecutorFactory()
        {
            //Arrange
            var type = typeof(IQueryExecutorFactory);

            //Act
            var factory = Factory();

            //Assert
            Assert.IsInstanceOf(type, factory);
        }

        private static QueryExecutorFactory Factory()
        {
            var resolverMock = new Mock<IResolver>();
            var queryHandlerMock = new Mock<IQueryHandler<SomeQuery, SomeObject>>();

            resolverMock.Setup(p => p.Resolve(typeof(QueryExecutor<SomeQuery, SomeObject>)))
                .Returns(new QueryExecutor<SomeQuery, SomeObject>(queryHandlerMock.Object));

            var executorFactory = new QueryExecutorFactory(resolverMock.Object);
            return executorFactory;

        }

        [Test]
        public void Get_Return_IQueryExecutor_Of_SomeObject()
        {
            //Arrange
            var type = typeof(IQueryExecutor<SomeObject>);
            var factory = Factory();

            //Act
            var executor = factory.Get<SomeObject>(typeof(QueryExecutor<SomeQuery, SomeObject>));

            //Assert
            Assert.IsInstanceOf(type, executor);
        }
    }
}