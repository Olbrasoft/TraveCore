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
            var type = typeof(BaseRealEstateDto);

            //Act
            var accommodationItem = new RealEstateItem();

            //Assert
            Assert.IsInstanceOf(type, accommodationItem);
        }
    }
}