using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Geography;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Geography
{
    public class RegionToRegionTest
    {
        [Test]
        public void Region()
        {
            //Arrange
            var region = new Region();

            //Act
            var to = new RegionToRegion
            {
                Region = region
            };

            //Assert
            Assert.AreSame(region, to.Region);
        }

        [Test]
        public void ParentRegion()
        {
            //Arrange
            var region = new Region();

            //Act
            var to = new RegionToRegion
            {
                ParentRegion = region
            };

            //Assert
            Assert.AreSame(region, to.ParentRegion);
        }
    }
}