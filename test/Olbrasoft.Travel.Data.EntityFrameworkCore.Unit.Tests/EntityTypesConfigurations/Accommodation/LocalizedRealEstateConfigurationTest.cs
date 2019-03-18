using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Accommodation
{
    [TestFixture]
    internal class LocalizedRealEstateConfigurationTest
    {
        [Test]
        public void Instance_Is_LocalizedConfiguration_Of_LocalizedAccommodation()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<LocalizedRealEstate>);

            //Act
            var configuration = new LocalizedRealEstateConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}