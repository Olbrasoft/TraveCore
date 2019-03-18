using NUnit.Framework;
using Olbrasoft.Travel.Data.Geography;
using RegionToSubclass = Olbrasoft.Travel.Data.Geography.RegionToSubclass;

namespace Olbrasoft.Travel.Data.Unit.Tests.Geography
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