using NUnit.Framework;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Linq;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Object
{
    [TestFixture]
    internal class RoomPhotoTest
    {
        [Test]
        public void CallConstructorAndFillProperties()
        {
            //Arrange
            var photosToRooms = new[]
            {
                new PhotoToRoom()
            }.AsEnumerable();

            var roomPhoto = new RoomPhoto
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
                Assert.IsTrue(roomPhoto.PhotosToRooms.Count()==1);

            });
        }
    }
}