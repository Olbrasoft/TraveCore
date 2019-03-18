using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class RealEstateToAttributeTest
    {
        [Test]
        public void RealEstateId()
        {
            //Arrange
            const int id = 1976;

            //Act
            var to = new RealEstateToAttribute
            {
                RealEstateId = id
            };

            //Assert
            Assert.AreEqual(id, to.RealEstateId);
        }
    }
}