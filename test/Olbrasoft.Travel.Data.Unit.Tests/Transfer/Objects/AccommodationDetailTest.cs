using NUnit.Framework;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Objects
{
    [TestFixture]
    internal class AccommodationDetailTest
    {
        [Test]
        public void Instance_Is_Accommodation()
        {
            //Arrange
            var type = typeof(BaseRealEstateDto);

            //Act
            var accommodationDetail = new RealEstateDetail();

            //Assert
            Assert.IsInstanceOf(type, accommodationDetail);
        }

        [Test]
        public void Instance_Implement_Interface_IHaveRooms()
        {
            //Arrange
            var type = typeof(IHaveRooms);

            //Act
            var accommodationDetail = new RealEstateDetail();

            //Assert
            Assert.IsInstanceOf(type, accommodationDetail);
        }

        [Test]
        public void Instance_Implement_Interface_IHaveAttributes()
        {
            //Arrange
            var type = typeof(IHaveAttributes);

            //Act
            var accommodationDetail = new RealEstateDetail();

            //Assert
            Assert.IsInstanceOf(type, accommodationDetail);
        }

    }
}