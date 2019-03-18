using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Geography;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Geography
{
    [TestFixture]
    internal class AirportConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration_Of_Airport()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<Airport>);

            //Act
            var configuration = new AirportConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}