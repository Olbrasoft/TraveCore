using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class PhotoTest
    {
        [Test]
        public void RealEstateId()
        {
            //Arrange
             const int estateId = 1976;

            //Act
            var photo = new Photo
            {
                RealEstateId = estateId
            };

            //Assert
            Assert.AreEqual(estateId, photo.RealEstateId);
        }

        [Test]
        public void FileName()
        {
            //Arrange
            const string name = "Some File Name";

            //Act
            var photo = new Photo
            {
                FileName = name
            };

            //Assert
            Assert.AreEqual(name, photo.FileName);
        }

        
    }
}