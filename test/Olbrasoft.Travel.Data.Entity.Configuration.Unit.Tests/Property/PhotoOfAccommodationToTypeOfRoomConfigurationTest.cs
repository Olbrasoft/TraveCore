using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Property;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Property
{
    [TestFixture]
    internal class PhotoOfAccommodationToTypeOfRoomConfigurationTest
    {
        [Test]
        public void Instance_Is_ManyToManyConfiguration_Of_PhotoOfAccommodationToTypeOfRoom()
        {
            //Arrange
            var type = typeof(ManyToManyConfiguration<PhotoOfAccommodationToTypeOfRoom>);

            //Act
            var configuration = new PhotoOfAccommodationToTypeOfRoomConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}