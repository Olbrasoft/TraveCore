using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Geography;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Geography
{
    [TestFixture]
    internal class ContinentConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration_Of_Continent()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<Continent>);

            //Act
            var configuration = new ContinentConfiguration();

            //Assert
            Assert.IsInstanceOf(type,configuration);
        }
    }
}