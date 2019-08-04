using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Geography;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Geography
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
            var configuration = new RegionToRegionConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}