using System.Collections.Generic;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Base.Objects.Geography;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Geography
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