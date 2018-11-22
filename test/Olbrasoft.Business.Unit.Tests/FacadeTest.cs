using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Query;

namespace Olbrasoft.Business.Unit.Tests
{
    [TestFixture]
    internal class FacadeTest
    {
        private static SomeFacade Facade()
        {
            var providerMock = new Mock<IProvider>();
            return new SomeFacade(providerMock.Object);
        }

        [Test]
        public void Instance_Is_Facade()
        {
            //Arrange
            var type = typeof(Facade);

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