using System.Collections.Generic;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Base.Objects.Geography;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Geography
{
    [TestFixture]
    internal class CountryTest
    {
        [Test]
        public void Instance_Is_ExpandingInformationAboutRegion()
        {
            //Arrange
            var type = typeof(ExpandingInformationAboutRegion);

            //Act
            var country = new Country();

            //Assert
            Assert.IsInstanceOf(type, country);
        }

        [Test]
        public void Accommodations()
        {
            //Arrange
            var estates = new List<Property>();

            //Act
            var country = new Country
            {
                Accommodations = estates
            };

            //Assert
            Assert.AreSame(estates, country.Accommodations);
        }
    }
}