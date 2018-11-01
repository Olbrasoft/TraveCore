using AutoMapper;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Olbrasoft.Travel.Data.Mapping.Unit.Tests
{
    [TestFixture]
    internal class LocalizedTypesOfRoomsToRoomsTest
    {
        [Test]
        public void Instance_Is_Profile()
        {
            //Arrange
            var type = typeof(Profile);

            //Act
            var profile = new LocalizedTypesOfRoomsToRooms();

            //Assert
            Assert.IsInstanceOf(type, profile);
        }
    }
}