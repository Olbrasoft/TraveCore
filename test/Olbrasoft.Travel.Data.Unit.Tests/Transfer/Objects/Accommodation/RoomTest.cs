﻿using NUnit.Framework;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Objects.Accommodation
{
    [TestFixture]
    internal class RoomTest
    {
        [Test]
        public void CallConstructorAndFillProperties()
        {
            //Arrange
            var room = new RoomDto
            {
                Id = 1,
                Name = "Name",
                Description = "Description",
                Photos = new[] { "", "", "" }
            };

            //Act
            var id = room.Id;
            var name = room.Name;
            var description = room.Description;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(id == 1);
                Assert.IsTrue(name == "Name");
                Assert.IsTrue(description == "Description");
                Assert.IsTrue(room.Photos.Length == 3);
            });
        }
    }
}