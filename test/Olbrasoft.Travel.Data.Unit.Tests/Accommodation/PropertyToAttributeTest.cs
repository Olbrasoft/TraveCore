using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class PropertyToAttributeTest
    {
        [Test]
        public void Id()
        {
            //Arrange
            const int id = 1976;

            //Act
            var to = new PropertyToAttribute
            {
                PropertyId = id
            };

            //Assert
            Assert.AreEqual(id, to.PropertyId);
        }
    }
}