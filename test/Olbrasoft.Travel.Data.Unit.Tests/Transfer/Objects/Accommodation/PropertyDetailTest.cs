using NUnit.Framework;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Objects.Accommodation
{
    [TestFixture]
    internal class PropertyDetailTest
    {
        [Test]
        public void Instance_Is_Accommodation()
        {
            //Arrange
            var type = typeof(BasePropertyDto);

            //Act
            var accommodationDetail = new PropertyDetail();

            //Assert
            Assert.IsInstanceOf(type, accommodationDetail);
        }

        [Test]
        public void Instance_Implement_Interface_IHaveRooms()
        {
            //Arrange
            var type = typeof(IHaveRooms);

            //Act
            var accommodationDetail = new PropertyDetail();

            //Assert
            Assert.IsInstanceOf(type, accommodationDetail);
        }

        [Test]
        public void Instance_Implement_Interface_IHaveAttributes()
        {
            //Arrange
            var type = typeof(IHaveAttributes);

            //Act
            var accommodationDetail = new PropertyDetail();

            //Assert
            Assert.IsInstanceOf(type, accommodationDetail);
        }

    }
}