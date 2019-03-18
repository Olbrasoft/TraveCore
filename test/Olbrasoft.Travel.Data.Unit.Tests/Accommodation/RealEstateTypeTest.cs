using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{

    public class RealEstateTypeTest
    {
        [Test]
        public void LocalizedPropertyTypes()
        {
            //Arrange
            var localizedTypeOfAccommodations = new[] {new LocalizedRealEstateType()};

            //Act
            var toa = new RealEstateType
            {
                LocalizedPropertyTypes = localizedTypeOfAccommodations
            };

            //Assert
            Assert.AreSame(localizedTypeOfAccommodations, toa.LocalizedPropertyTypes);

        }
    }
}