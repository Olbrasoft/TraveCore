using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Property
{
    [TestFixture]
    internal class TypeOfRoomConfigurationTest
    {
        [Test]
        public void Instance_Is_CreatorConfiguration_Of_TypeOfRoom()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<Room>);

            //Act
            var configuration = new RoomConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}