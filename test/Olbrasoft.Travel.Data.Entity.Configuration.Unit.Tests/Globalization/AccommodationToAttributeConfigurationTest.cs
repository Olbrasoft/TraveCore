using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Globalization;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Globalization
{
    [TestFixture]
    internal class AccommodationToAttributeConfigurationTest
    {
        [Test]
        public void Instance_Is_GlobalizationConfiguration_Of_AccommodationToAttribute()
        {
            //Arrange
            var type = typeof(GlobalizationConfiguration<AccommodationToAttribute>);

            //Act
            var configuration = new AccommodationToAttributeConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}