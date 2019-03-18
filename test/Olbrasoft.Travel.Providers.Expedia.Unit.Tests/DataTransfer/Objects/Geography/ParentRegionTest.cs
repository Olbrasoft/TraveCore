using NUnit.Framework;
using Olbrasoft.Travel.Providers.Expedia.DataTransfer.Objects.Geography;

namespace Olbrasoft.Travel.Providers.Expedia.Unit.Tests.DataTransfer.Objects.Geography
{
    [TestFixture]
    public class ParentRegionTest
    {
        [Test]
        public void Instance_Is_Object()
        {
            //Arrange
            var type = typeof(object);

            //Act
            var region = new ParentRegion();

            //Assert
            Assert.IsInstanceOf(type, region);
        }
    }
}