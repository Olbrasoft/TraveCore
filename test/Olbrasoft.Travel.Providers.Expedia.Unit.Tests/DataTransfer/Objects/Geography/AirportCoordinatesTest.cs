using NUnit.Framework;
using Olbrasoft.Travel.Providers.Expedia.DataTransfer.Objects.Geography;

namespace Olbrasoft.Travel.Providers.Expedia.Unit.Tests.DataTransfer.Objects.Geography
{
    [TestFixture]
    public class AirportCoordinatesTest
    {
        [Test]
        public void Instance_Is_Object()
        {
            //Arrange
            var type = typeof(object);

            //Act
            var airportCoordinates = new AirportCoordinates();

            //Assert
            Assert.IsInstanceOf(type, airportCoordinates);
        }
    }
}