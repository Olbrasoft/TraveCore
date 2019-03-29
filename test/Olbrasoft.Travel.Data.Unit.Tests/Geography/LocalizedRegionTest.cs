using NUnit.Framework;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.Unit.Tests.Geography
{
    [TestFixture]
    internal class LocalizedRegionTest
    {
        [Test]
        public void Instance_Is_Localized()
        {
            //Arrange
            var type = typeof(Translation);

            //Act
            var localizedRegion = new RegionTranslation();

            //Assert
            Assert.IsInstanceOf(type, localizedRegion);
        }
    }
}