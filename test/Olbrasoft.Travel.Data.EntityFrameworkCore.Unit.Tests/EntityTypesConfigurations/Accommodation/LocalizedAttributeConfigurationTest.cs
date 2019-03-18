using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Accommodation
{
    [TestFixture]
    internal class LocalizedAttributeConfigurationTest
    {
        [Test]
        public void Instance_Is_LocalizedConfiguration_Of_LocalizedAttribute()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<LocalizedAttribute>);

            //Act
            var configuration = new LocalizedAttributeConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}