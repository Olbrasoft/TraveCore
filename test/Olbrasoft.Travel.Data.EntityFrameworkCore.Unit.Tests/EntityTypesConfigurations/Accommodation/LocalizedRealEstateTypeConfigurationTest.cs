using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Accommodation
{
    [TestFixture]
    internal class LocalizedRealEstateTypeConfigurationTest
    {
        [Test]
        public void Instance_Is_LocalizedConfiguration_Of_LocalizedTypeOfAccommodation()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<LocalizedRealEstateType>);

            //Act
            var configuration = new LocalizedRealEstateTypeConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}