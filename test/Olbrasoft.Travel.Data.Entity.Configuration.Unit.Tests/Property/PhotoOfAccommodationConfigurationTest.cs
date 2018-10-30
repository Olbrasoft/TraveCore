using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Property;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Property
{
    [TestFixture]
    internal class PhotoOfAccommodationConfigurationTest
    {
        [Test]
        public void Instance_Is_CreatorConfiguration_Of_PhotoOfAccommodation()
        {
            //Arrange
            var type = typeof(CreatorConfiguration<PhotoOfAccommodation>);

            //Act
            var configuration = new PhotoOfAccommodationConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }

        [Test]
        public void Instance_Is_PropertyConfiguration_Of_PhotoOfAccommodation()
        {
            //Arrange
            var type = typeof(PropertyConfiguration<PhotoOfAccommodation>);

            //Act
            var configuration = new PhotoOfAccommodationConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);

        }
    }
}