using NUnit.Framework;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests
{
    [TestFixture]
    internal class GeographyDatabaseContextTest
    {
        [Test]
        public void Instance_Is_TravelContext()
        {
            //Arrange
            var type = typeof(TravelDatabaseContext);

            //Act
            var context = GetContext();

            //Assert
            Assert.IsInstanceOf(type, context);
        }

        [Test]
        public void Instance_Implement_Interface_IGeography()
        {
            //Arrange
            var type = typeof(IGeographyContext);

            //Act
            var context = GetContext();

            //Assert
            Assert.IsInstanceOf(type, context);
        }

        private static GeographyDatabaseContext GetContext()
        {
            return new GeographyDatabaseContext();
        }
    }
}