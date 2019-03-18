using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Unit.Tests.Querying
{
    [TestFixture]
    internal class QueryDispatcherTest
    {
        [Test]
        public void Instance_Implement_Interface_IQueryDispatcher()
        {
            //Arrange
            var type = typeof(IQueryDispatcher);

            //Act
            var dispatcher = Dispatcher();

            //Assert
            Assert.IsInstanceOf(type, dispatcher);
        }

        [Test]
        public void Dispatch_Return_SomeObject()
        {
            //Arrange
            var type = typeof(SomeObject);
            var dispatcher = Dispatcher();

            //Act
            var result = dispatcher.Dispatch(new SomeQuery());

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void DispatchAsync_Return_Task_Of_SomeObject()
        {
            //Arrange
            var type = typeof(Task<SomeObject>);
            var dispatcher = Dispatcher();

            //Act
            var result = dispatcher.DispatchAsync(new SomeQuery());

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        private static QueryDispatcher Dispatcher()
        {
            var executorFactoryMock = new Mock<IQueryExecutorFactory>();
            var executorMock = new Mock<IQueryExecutor<SomeObject>>();
            executorMock.Setup(p => p.Execute(It.IsAny<SomeQuery>())).Returns(new SomeObject());
            executorMock.Setup(p => p.ExecuteAsync(It.IsAny<SomeQuery>(), default(CancellationToken))).Returns(Task.FromResult(new SomeObject()));

            executorFactoryMock.Setup(p => p.Get<SomeObject>(typeof(QueryExecutor<SomeQuery, SomeObject>)))
                .Returns(executorMock.Object);

            var dispatcher = new QueryDispatcher(executorFactoryMock.Object);
            return dispatcher;
        }
    }
}