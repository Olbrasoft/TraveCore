using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Property
{
    [TestFixture]
    internal class PhotoOfAccommodationToTypeOfRoomConfigurationTest
    {
        [Test]
        public void Instance_Is_ManyToManyConfiguration_Of_PhotoOfAccommodationToTypeOfRoom()
        {
            //Arrange
            var type = typeof(ManyToManyConfiguration<PhotoToRoom>);

            //Act
            var configuration = new PhotoToRoomConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}