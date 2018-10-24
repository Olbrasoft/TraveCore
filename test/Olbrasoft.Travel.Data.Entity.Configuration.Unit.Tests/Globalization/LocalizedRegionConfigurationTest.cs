using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Globalization;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Globalization
{
    [TestFixture]
    internal class LocalizedRegionConfigurationTest
    {
        [Test]
        public void Instance_Is_GlobalizationConfiguration_Of_LocalizedRegion()
        {
            //Arrange
            var type = typeof(GlobalizationConfiguration<LocalizedRegion>);

            //Act
            var configuration = new LocalizedRegionConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}