using NUnit.Framework;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Objects
{
    [TestFixture]
    internal class AccommodationItemTest
    {
        [Test]
        public void Instance_Is_Accommodation()
        {
            //Arrange
            var type = typeof(BaseAccommodationDto);

            //Act
            var accommodationItem = new AccommodationItem();

            //Assert
            Assert.IsInstanceOf(type, accommodationItem);
        }
    }
}