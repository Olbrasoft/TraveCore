using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Accommodation
{
    [TestFixture]
    internal class LocalizedRoomConfigurationTest
    {
        [Test]
        public void Instance_Is_LocalizedConfiguration_Of_LocalizedTypeOfRoom()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<LocalizedRoom>);

            //Act
            var configuration = new LocalizedRoomConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}