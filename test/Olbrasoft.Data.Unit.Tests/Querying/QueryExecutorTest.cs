using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Unit.Tests.Querying
{
    [TestFixture]
    internal class QueryExecutorTest
    {
        [Test]
        public void Instance_Implement_Interface_IQueryExecutor()
        {
            //Arrange
            var type = typeof(IQueryExecutor<SomeObject>);

            //Act
            var executor = Executor();

            //Assert
            Assert.IsInstanceOf(type, executor);
        }

        private static QueryExecutor<SomeQuery, SomeObject> Executor()
        {
            var queryHandlerMock = new Mock<IQueryHandler<SomeQuery, SomeObject>>();
            queryHandlerMock.Setup(p => p.Handle(It.IsAny<SomeQuery>())).Returns(new SomeObject());

            var executor = new QueryExecutor<SomeQuery, SomeObject>(queryHandlerMock.Object);
            return executor;
        }

        [Test]
        public void Execute_Return_Object()
        {
            //Arrange
            var type = typeof(object);
            var executor = Executor();
            var query = Query();

            //Act
            var result = executor.Execute(query);

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        private static SomeQuery Query()
        {
            var query = new SomeQuery();
            return query;
        }

        [Test]
        public void ExecuteAsync_Return_TaskOfObject()
        {
            //Arrange
            var type = typeof(Task<SomeObject>);
            var executor = Executor();
            var query = Query();

            //Act
            var result = executor.ExecuteAsync(query);

            //Assert
            Assert.IsInstanceOf(type, result);
        }
    }
}