using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Accommodation
{
    [TestFixture]
    internal class RealEstateToAttributeConfigurationTest
    {
        [Test]
        public void Instance_Is_GlobalizationConfiguration_Of_AccommodationToAttribute()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<RealEstateToAttribute>);

            //Act
            var configuration = new RealEstateToAttributeConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}