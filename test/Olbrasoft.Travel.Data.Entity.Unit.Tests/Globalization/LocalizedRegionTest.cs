using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Unit.Tests.Globalization
{
    [TestFixture]
    internal class LocalizedRegionTest
    {
        [Test]
        public void Instance_Is_Localized()
        {
            //Arrange
            var type = typeof(Localized);

            //Act
            var localizedRegion = new LocalizedRegion();

            //Assert
            Assert.IsInstanceOf(type, localizedRegion);
        }
    }
}