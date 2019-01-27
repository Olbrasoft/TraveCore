using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Query;

namespace Olbrasoft.Business.Unit.Tests
{
    [TestFixture]
    internal class ServiceTest
    {
        private static SomeService Facade()
        {
            var providerMock = new Mock<IProvider>();
            return new SomeService(providerMock.Object);
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
            var provider = facade.QueryProvider;

            //Assert
            Assert.IsInstanceOf<IProvider>(provider);
        }
    }
}