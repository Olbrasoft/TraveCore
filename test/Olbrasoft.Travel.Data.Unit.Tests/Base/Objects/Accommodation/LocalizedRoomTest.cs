using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Accommodation
{
    public class LocalizedRoomTest
    {
        [Test]
        public void Name()
        {
            //Arrange
            const string name = "Some Name";

            //Act
            var localization = new RoomTranslation
            {
                Name = name
            };

            //Assert
            Assert.AreEqual(name, localization.Name);
        }

        [Test]
        public void Type()
        {
            //Arrange
            var type = new Room();

            //Act
            var localization = new RoomTranslation
            {
                Type = type
            };

            //Assert
            Assert.AreSame(type, localization.Type);
        }

        [Test]
        public void Description()
        {
            //Arrange
            const string description = "Some Description";

            //Act
            var localization = new RoomTranslation
            {
                Description = description
            };

            //Assert
            Assert.AreEqual(description, localization.Description);
        }
    }
}