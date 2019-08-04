using System.Collections.Generic;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Base.Objects.Geography;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Accommodation
{
    public class PropertyTest
    {
        [Test]
        public void Address()
        {
            //Arrange
            const string address = "Some Address";

            //Act
            var estate = new Property
            {
                Address = address
            };

            //Assert
            Assert.AreEqual(address, estate.Address);
        }

        [Test]
        public void ToRegions()
        {
            //Arrange
            ICollection<PropertyToRegion> toRegions = new List<PropertyToRegion>();

            var property = Create();

            //Act
            property.ToRegions = toRegions;

            //Assert
            Assert.AreSame(toRegions,property.ToRegions);
        }

        private static Property Create()
        {
            var property = new Property();
            return property;
        }
    }
}