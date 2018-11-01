using AutoMapper;
using NUnit.Framework;

namespace Olbrasoft.Travel.Data.Mapping.Unit.Tests
{
    [TestFixture]
    internal class PhotoOfAccommodationToRoomPhotoTest
    {
        [Test]
        public void Instance_Is_Profile()
        {
            //Arrange
            var type = typeof(Profile);

            //Act
            var profile = new PhotoOfAccommodationToRoomPhoto();

            //Assert
            Assert.IsInstanceOf(type, profile);
        }
    }
}