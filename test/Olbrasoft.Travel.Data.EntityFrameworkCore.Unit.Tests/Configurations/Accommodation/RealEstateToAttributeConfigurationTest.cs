using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Accommodation
{
    [TestFixture]
    internal class RealEstateToAttributeConfigurationTest
    {
        [Test]
        public void Instance_Is_GlobalizationConfiguration_Of_AccommodationToAttribute()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<PropertyToAttribute>);

            //Act
            var configuration = new PropertyToAttributeConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}