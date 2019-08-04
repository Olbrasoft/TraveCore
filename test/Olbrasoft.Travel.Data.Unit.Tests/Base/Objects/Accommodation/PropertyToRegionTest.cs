using NUnit.Framework;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Base.Objects.Geography;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Accommodation
{
    public class PropertyToRegionTest
    {
        [Test]
        public void Instance_Is_ManyToMany()
        {
            //Arrange
            var type = typeof(ManyToMany);

            //Act
            var propertyToRegion = Create();

            //Assert
            Assert.IsInstanceOf(type, propertyToRegion);
        }

        private static PropertyToRegion Create()
        {
            var regionToProperty = new PropertyToRegion();
            return regionToProperty;
        }

        [Test]
        public void Region()
        {
            //Arrange
            var region = new Region();
            var regionToProperty = Create();

            //Act
            regionToProperty.Region = region;

            //Assert
            Assert.AreSame(region, regionToProperty.Region);
        }

        [Test]
        public void Property()
        {
            //Arrange
            var property = new Data.Base.Objects.Accommodation.Property();
            var regionToProperty = Create();

            //Act
            regionToProperty.Property = property;

            //Assert
            Assert.AreSame(property, regionToProperty.Property);
        }
    }
}