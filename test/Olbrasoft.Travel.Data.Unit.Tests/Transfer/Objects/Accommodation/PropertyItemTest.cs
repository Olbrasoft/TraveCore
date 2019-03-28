using NUnit.Framework;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Objects.Accommodation
{
    [TestFixture]
    internal class PropertyItemTest
    {
        [Test]
        public void Instance_Is_Accommodation()
        {
            //Arrange
            var type = typeof(BasePropertyDto);

            //Act
            var accommodationItem = new PropertyItem();

            //Assert
            Assert.IsInstanceOf(type, accommodationItem);
        }
    }
}