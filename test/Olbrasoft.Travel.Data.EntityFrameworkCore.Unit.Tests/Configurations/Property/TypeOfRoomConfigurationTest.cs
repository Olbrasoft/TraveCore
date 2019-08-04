using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Property
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