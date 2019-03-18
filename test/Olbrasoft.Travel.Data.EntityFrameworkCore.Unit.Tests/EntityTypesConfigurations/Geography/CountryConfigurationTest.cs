using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Geography;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Geography
{
    [TestFixture]
    internal class CountryConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration_Of_Country()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<Country>);

            //Act
            var configuration = new CountryConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}