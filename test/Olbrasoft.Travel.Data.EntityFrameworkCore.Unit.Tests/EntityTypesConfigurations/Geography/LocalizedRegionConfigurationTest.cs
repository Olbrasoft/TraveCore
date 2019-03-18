using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Geography;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Geography
{
    [TestFixture]
    internal class LocalizedRegionConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration_Of_LocalizedRegion()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<LocalizedRegion>);

            //Act
            var configuration = new LocalizedRegionConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}