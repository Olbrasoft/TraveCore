using NUnit.Framework;
using Olbrasoft.Extensions;

namespace Olbrasoft.Travel.Data.Unit.Tests
{
    [TestFixture]
    internal class AccommodationTest
    {
        [Test]
        public void Instance_Implement_Interface_IAccommodation()
        {
            //Arrange
            var type = typeof(IAccommodation);

            //Act
            var accommodation = new Accommodation();

            //Assert
            Assert.IsInstanceOf(type, accommodation);
        }

        [Test]
        public void IAccommodation_StarRating()
        {
            //Arrange
            IAccommodation accommodation = new Accommodation
            {
                StarRating = new decimal(3.5)
            };

            //Act
            var stars = (int) accommodation.StarRating;
            var isInteger = (accommodation.StarRating % 1) == 0;

            //Assert
            Assert.Multiple(
                () =>
                {
                    Assert.IsTrue(stars == 3);
                    Assert.IsFalse(isInteger);
                    Assert.IsFalse(accommodation.StarRating.IsInteger());
                });
         
        }
    }
}