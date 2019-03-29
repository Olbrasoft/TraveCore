using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Geography;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Geography
{
    [TestFixture]
    internal class LocalizedRegionConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration_Of_LocalizedRegion()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<RegionTranslation>);

            //Act
            var configuration = new RegionTranslationConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}