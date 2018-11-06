using NUnit.Framework;
using NUnit.Framework.Internal;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Object
{
    [TestFixture]
    internal class PhotoToRoomTest
    {
        [Test]
        public void Create_And_Fill_Properties()
        {
            //Arrange
            var photoToRoom = new PhotoToRoom
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