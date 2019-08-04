using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Geography;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using RegionToSubclass = Olbrasoft.Travel.Data.Base.Objects.Geography.RegionToSubclass;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Geography
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
            var regionsToSubclasses = new[] { new RegionToSubclass() };
            var region = new Region
            {
                ToSubclasses = regionsToSubclasses
            };

            //Act
            var result = region.ToSubclasses;

            //Assert
            Assert.IsInstanceOf<ICollection<RegionToSubclass>>(result);
        }

        [Test]
        public void ToProperties()
        {
            //Arrange
            ICollection<PropertyToRegion> toProperties = new List<PropertyToRegion>();
            var region = Create();

            //Act
            region.ToProperties = toProperties;

            //Assert
            Assert.AreSame(toProperties, region.ToProperties);
        }

        private static Region Create()
        {
            var region = new Region();
            return region;
        }
    }
}