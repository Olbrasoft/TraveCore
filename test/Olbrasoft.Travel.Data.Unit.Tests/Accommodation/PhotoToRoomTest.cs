using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class PhotoToRoomTest
    {
        [Test]
        public void Photo()
        {
            //Arrange
            var photo = new Photo();

            //Act
            var photoToRoom = new PhotoToRoom
            {
                Photo = photo
            };

            //Assert
            Assert.AreSame(photo, photoToRoom.Photo);
        }

        [Test]
        public void RoomType()
        {
            //Arrange
            var type = new Room();

            //Act
            var photoToRoom = new PhotoToRoom { Room = type };

            //Assert
            Assert.AreSame(type, photoToRoom.Room);
        }
    }
}