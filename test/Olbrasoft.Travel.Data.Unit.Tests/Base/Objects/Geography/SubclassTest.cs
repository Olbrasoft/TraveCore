using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Geography;
using RegionToSubclass = Olbrasoft.Travel.Data.Base.Objects.Geography.RegionToSubclass;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Geography
{
    [TestFixture]
    public class SubclassTest
    {
        [Test]
        public void ToRegions()
        {
            //Arrange
            var regionsToSubclasses = new[] { new RegionToSubclass() };
            var subclass = new Subclass
            {
                ToRegions = regionsToSubclasses
            };

            //Act
            var result = subclass.ToRegions;

            //Assert
            Assert.AreSame(regionsToSubclasses, result);
        }
    }
}