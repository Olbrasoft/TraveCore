using NUnit.Framework;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests
{
    [TestFixture]
    internal class GlobalizationDatabaseContextTest
    {
        [Test]
        public void Instance_Is_TravelDatabaseContext()
        {
            //Arrange
            var type = typeof(TravelDatabaseContext);

            //Act
            var context = new GlobalizationDatabaseContext();

            //Assert
            Assert.IsInstanceOf(type, context);
        }

        [Test]
        public void Instance_Implement_Interface_IGlobalization()
        {
            //Arrange
            var type = typeof(IGlobalizationContext);

            //Act
            var context= new GlobalizationDatabaseContext();

            //Assert
            Assert.IsInstanceOf(type,context);
        }
    }
}