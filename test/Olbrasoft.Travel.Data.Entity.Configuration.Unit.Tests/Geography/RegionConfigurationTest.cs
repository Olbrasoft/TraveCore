using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Geography;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Geography
{
    [TestFixture]
    internal class RegionConfigurationTest
    {
        [Test]
        public void Instance_Is_GeographyConfiguration_Of_Region()
        {
            //Arrange
            var type = typeof(GeographyConfiguration<Region>);

            //Act
            var configuration = new RegionConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}