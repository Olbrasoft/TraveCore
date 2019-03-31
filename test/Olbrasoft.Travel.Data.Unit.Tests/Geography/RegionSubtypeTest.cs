using NUnit.Framework;
using Olbrasoft.Travel.Data.Geography;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Unit.Tests.Geography
{
    [TestFixture]
    internal class RegionSubtypeTest
    {
        [Test]
        public void Description()
        {
            //Arrange
            const string description = "Description of RegionSubtype.";
            var regionType = new RegionSubtype
            {
                Description = description
            };

            //Act
            var result = regionType.Description;

            //Assert
            Assert.IsTrue(result == description);
        }

        [Test]
        public void Regions()
        {
            //Arrange
            ICollection<Region> regions = new[] { new Region() };
            var type = new RegionSubtype
            {
                Regions = regions
            };

            //Act
            var result = type.Regions;

            //Assert
            Assert.AreSame(regions, result);
        }
    }
}