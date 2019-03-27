using System.Collections.Generic;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Geography;
using RegionToSubclass = Olbrasoft.Travel.Data.Geography.RegionToSubclass;

namespace Olbrasoft.Travel.Data.Unit.Tests.Geography
{
    [TestFixture]
    public class RegionTest
    {
        [Test]
        public void Type()
        {
            //Arrange
            var type = new RegionSubtype();
            var region = new Region { Subtype = type };

            //Act
            var result = region.Subtype;

            //Assert
            Assert.AreSame(type, result);
        }

        [Test]
        public void SubtypeId()
        {
            //Arrange
            const int subtypeId = 1976;
            var r = new Region
            {
                SubtypeId = subtypeId
            };

            //Act
            var result = r.SubtypeId;


            //Assert
            Assert.AreEqual(subtypeId, result);
        }


        [Test]
        public void ToSubclasses()
        {
            //Arrange
            var regionsToSubclasses = new[] {new RegionToSubclass()};
            var region = new Region
            {
                ToSubclasses = regionsToSubclasses
            };

            //Act
            var result = region.ToSubclasses;

            //Assert
            Assert.IsInstanceOf<ICollection<RegionToSubclass>>(result);
        }




    }
}