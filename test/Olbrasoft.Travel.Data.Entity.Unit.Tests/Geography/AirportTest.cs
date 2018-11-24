using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Unit.Tests.Geography
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
    }
}