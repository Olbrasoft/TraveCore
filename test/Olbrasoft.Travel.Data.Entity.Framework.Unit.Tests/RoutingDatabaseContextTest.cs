using NUnit.Framework;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests
{
    [TestFixture]
    internal class RoutingDatabaseContextTest
    {
        [Test]
        public void Instance_Is_TravelDatabaseContext()
        {
            //Arrange
            var type = typeof(TravelDatabaseContext);

            //Act
            var context = new RoutingDatabaseContext();

            //Assert
            Assert.IsInstanceOf(type, context);
        }

        [Test]
        public void Instance_Implement_Interface_IRoutingContext()
        {
            //Arrange
            var type = typeof(IRoutingContext);

            //Act
            var context = new RoutingDatabaseContext();

            //Assert
            Assert.IsInstanceOf(type,context);
        }
    }
}