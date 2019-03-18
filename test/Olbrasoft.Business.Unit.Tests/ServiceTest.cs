using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.Business.Unit.Tests
{
    [TestFixture]
    internal class ServiceTest
    {
        private static SomeService Facade()
        {
            var factoryMock = new Mock<IQueryFactory>();

            return new SomeService(factoryMock.Object);
        }

        [Test]
        public void Instance_Is_Facade()
        {
            //Arrange
            var type = typeof(Service);

            //Act
            var facade = Facade();

            //Assert
            Assert.IsInstanceOf(type, facade);
        }

        [Test]
        public void QueryProvider_Implement_Interface_IProvider()
        {
            //Arrange
            var facade = Facade();

            //Act
            var provider = facade.QueryFactory;

            //Assert
            Assert.IsInstanceOf<IQueryFactory>(provider);
        }
    }
}