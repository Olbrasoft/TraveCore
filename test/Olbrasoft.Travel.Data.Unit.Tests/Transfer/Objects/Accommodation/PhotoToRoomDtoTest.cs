using NUnit.Framework;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Objects.Accommodation
{
    [TestFixture]
    internal class PhotoToRoomDtoTest
    {
        [Test]
        public void Create_And_Fill_Properties()
        {
            //Arrange
            var photoToRoom = new PhotoToRoomDto
            {
                PhotoId = 1,
                RoomId = 1
            };

            //Act
            var photoId = photoToRoom.PhotoId;
            var roomId = photoToRoom.RoomId;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(photoId == 1);
                Assert.IsTrue(roomId == 1);
            });
        }
    }
}