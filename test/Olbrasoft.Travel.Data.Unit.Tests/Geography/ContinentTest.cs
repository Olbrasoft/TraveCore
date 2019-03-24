using NUnit.Framework;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.Unit.Tests.Geography
{
    [TestFixture]
    internal class ContinentTest
    {
        [Test]
        public void Instance_Is_OwnerCreatorIdAndCreator()
        {
            //Arrange
            var type = typeof(OwnerCreatorInfoAndCreator);

            //Act
            var continent = new Continent();

            //Assert
            Assert.IsInstanceOf(type, continent);
        }

        [Test]
        public void Instance_Implement_Interface_IAdditionalRegionInfo()
        {
            //Arrange
            var type = typeof(IAdditionalRegionInfo);

            //Act
            var continent = Continent();

            //Assert
            Assert.IsInstanceOf(type, continent);
        }

        private static Continent Continent()
        {
            return new Continent();
        }

        [Test]
        public void Instance_Is_ExpandingInformationAboutRegion()
        {
            //Arrange
            var type = typeof(ExpandingInformationAboutRegion);

            //Act
            var continent = Continent();

            //Assert
            Assert.IsInstanceOf(type, continent);
        }
    }
}