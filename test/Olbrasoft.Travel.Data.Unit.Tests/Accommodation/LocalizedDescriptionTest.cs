using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class LocalizedDescriptionTest
    {



        [Test]
        public void RealEstateId()
        {
            //Arrange
            const int id = 1976;

            //Act
            var localization = new LocalizedDescription
            {
                RealEstateId = id
            };

            //Assert
            Assert.AreEqual(id, localization.RealEstateId);
        }
    }
}