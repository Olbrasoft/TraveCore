using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class RealEstateTest
    {
        [Test]
        public void Address()
        {
            //Arrange
            const string address = "Some Address";

            //Act
            var estate = new Property
            {
                Address = address
            };

            //Assert
            Assert.AreEqual(address, estate.Address);
        }
    }
}