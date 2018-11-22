using AutoMapper;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Olbrasoft.Travel.Data.Mapping.Unit.Tests
{
    [TestFixture]
    internal class LocalizedRegionToCountryItemTest
    {
        [Test]
        public void Instance_Is_Profile()
        {
            //Arrange
            var type = typeof(Profile);

            //Act
            var profile = new LocalizedRegionToCountryItem();

            //Assert
            Assert.IsInstanceOf(type,profile);
        }

    }
}