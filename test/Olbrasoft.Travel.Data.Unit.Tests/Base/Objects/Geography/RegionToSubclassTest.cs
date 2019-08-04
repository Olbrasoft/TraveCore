using NUnit.Framework;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Base.Objects.Geography;
using RegionToSubclass = Olbrasoft.Travel.Data.Base.Objects.Geography.RegionToSubclass;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Geography
{
    [TestFixture]
    public class RegionToSubclassTest
    {
        [Test]
        public void Instance_Is_ManyToMany()
        {
            //Arrange
            var type = typeof(ManyToMany);

            //Act
            var regionToSubclass = new RegionToSubclass();

            //Assert
            Assert.IsInstanceOf(type, regionToSubclass);
        }

        [Test]
        public void Region()
        {
            //Arrange
            var regionToSubclass = new RegionToSubclass
            {
                Region = new Region()
            };

            //Act
            var result = regionToSubclass.Region;

            //Assert
            Assert.IsInstanceOf<Region>(result);
        }

        [Test]
        public void MyTestMethod()
        {
            //Arrange
            var regionToSubclass = new RegionToSubclass
            {
                Subclass = new Subclass()
            };

            //Act
            var result = regionToSubclass.Subclass;

            //Assert
            Assert.IsInstanceOf<Subclass>(result);
        }
    }
}