using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class RoomTest
    {
        [Test]
        public void PropertyId()
        {
            //Arrange
            const int propertyId = 1976;

            //Act
            var room = new Room
            {
                PropertyId = propertyId
            };

            //Assert
            Assert.AreEqual(propertyId, room.PropertyId);
        }

        [Test]
        public void LocalizedRooms()
        {
            //Arrange
            var localizations = new List<RoomTranslation>();

            //Act
            var room = new Room
            {
                LocalizedRooms = localizations
            };

            //Assert
            Assert.AreSame(localizations, room.LocalizedRooms);
        }

        [Test]
        public void PhotosToRooms()
        {
            //Arrange
            var photoToRooms = new List<PhotoToRoom>();

            //Act
            var room = new Room
            {
                PhotosToRooms = photoToRooms
            };

            //Assert
            Assert.AreSame(photoToRooms, room.PhotosToRooms);
        }
    }
}