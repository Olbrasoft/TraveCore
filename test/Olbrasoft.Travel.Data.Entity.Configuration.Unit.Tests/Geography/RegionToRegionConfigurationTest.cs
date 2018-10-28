using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Geography;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Geography
{
    [TestFixture]
    internal class RegionToRegionConfigurationTest
    {
        [Test]
        public void Instance_Is_GeographyConfiguration()
        {
            //Arrange
            var type = typeof(GeographyConfiguration<RegionToRegion>);

            //Act
            var configuration= new RegionToRegionConfiguration();

            //Assert
            Assert.IsInstanceOf(type,configuration);

        }
    }
}
