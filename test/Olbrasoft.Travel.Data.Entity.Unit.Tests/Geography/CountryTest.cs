using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Unit.Tests.Geography
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
    }
}