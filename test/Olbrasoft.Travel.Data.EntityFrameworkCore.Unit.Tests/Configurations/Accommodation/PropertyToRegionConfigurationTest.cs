using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Accommodation
{
    public class PropertyToRegionConfigurationTest
    {
        [Test]
        public void Instance_Is_Travel_Type_Configuration_Of_RegionToProperty()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<PropertyToRegion>);

            //Act
            var configuration = new PropertyToRegionConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}