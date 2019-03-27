using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Geography;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Geography
{
    [TestFixture]
    internal class RegionSubtypeConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration_of_TypeOfRegion()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<RegionSubtype>);

            //Act
            var configuration = new RegionSubtypeConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}