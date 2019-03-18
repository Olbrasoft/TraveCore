using System.Collections.Generic;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.Unit.Tests.Geography
{
    [TestFixture]
    internal class SubtypeTest
    {
        [Test]
        public void Description()
        {
            //Arrange
            const string description = "Description of Subtype.";
            var regionType = new Subtype
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
            var type = new Subtype
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