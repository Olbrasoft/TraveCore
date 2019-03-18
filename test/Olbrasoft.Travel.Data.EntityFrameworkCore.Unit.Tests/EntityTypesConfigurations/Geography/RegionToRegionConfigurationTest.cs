using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Geography;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Geography
{
    [TestFixture]
    internal class RegionToRegionConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<RegionToRegion>);

            //Act
            var configuration= new RegionToRegionConfiguration();

            //Assert
            Assert.IsInstanceOf(type,configuration);

        }
    }
}
