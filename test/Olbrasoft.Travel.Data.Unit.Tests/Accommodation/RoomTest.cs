using System.Collections.Generic;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class RoomTest
    {
        [Test]
        public void RealEstateId()
        {
            //Arrange
            const int estateId = 1976;

            //Act
            var room = new Room
            {
                RealEstateId= estateId
            };

            //Assert
            Assert.AreEqual(estateId, room.RealEstateId);
        }

        [Test]
        public void LocalizedRooms()
        {
            //Arrange
            var localizations = new List<LocalizedRoom>();


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