using System.Linq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Objects.Accommodation
{
    [TestFixture]
    internal class RoomPhotoDtoTest
    {
        [Test]
        public void Instance_Is_PhotoDto()
        {
            //Arrange
            var type = typeof(PhotoDto);

            //Act
            var photo = new RoomPhotoDto();

            //Assert
            Assert.IsInstanceOf(type, photo);
        }

        [Test]
        public void CallConstructorAndFillProperties()
        {
            //Arrange
            var photosToRooms = new[]
            {
                new PhotoToRoomDto()
            }.AsEnumerable();

            var roomPhoto = new RoomPhotoDto
            {
                Path = "Path",
                Name = "Name",
                Extension = "Extension",
                PhotosToRooms = photosToRooms
            };

            //Act
            var path = roomPhoto.Path;
            var name = roomPhoto.Name;
            var extension = roomPhoto.Extension;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(path == "Path");
                Assert.IsTrue(name == "Name");
                Assert.IsTrue(extension == "Extension");
                Assert.IsTrue(roomPhoto.PhotosToRooms.Count() == 1);
            });
        }
    }
}