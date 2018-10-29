using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Geography;

using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Property
{
    [TestFixture]
    internal class AccommodationConfigurationTest
    {
        [Test]
        public void Instance_Is_CreatorConfiguration_Of_Accommodation()
        {
            //Arrange
            var type = typeof(PropertyConfiguration<Accommodation>);

            //Act
            var configuration = new Configuration.Property.AccommodationConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}