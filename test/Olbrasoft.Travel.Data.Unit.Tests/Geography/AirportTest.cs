using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.Unit.Tests.Geography
{
    [TestFixture]
    internal class AirportTest
    {
        [Test]
        public void Inherits_from_ExpandingInformationAboutRegion()
        {
            //Arrange
            var type = typeof(ExpandingInformationAboutRegion);

            //Act
            var region = new Airport();

            //Assert
            Assert.IsInstanceOf(type, region);
        }

        [Test]
        public void Accommodations()
        {
            //Arrange
            var estates = new List<Property>();

            //Act
            var air = new Airport
            {
                Accommodations = estates
            };

            //Assert
            Assert.AreSame(estates, air.Accommodations);
        }
    }
}