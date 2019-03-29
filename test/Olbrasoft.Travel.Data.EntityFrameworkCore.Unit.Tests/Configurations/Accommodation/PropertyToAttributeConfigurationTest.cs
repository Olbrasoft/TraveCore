using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Accommodation
{
    [TestFixture]
    internal class PropertyToAttributeConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration_Of_PropertyToAttribute()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<PropertyToAttribute>);

            //Act
            var configuration = new PropertyToAttributeConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}