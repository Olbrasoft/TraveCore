using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Localization
{
    internal class LanguageConfigurationTest
    {
        [Test]
        public void Instance_Is_GlobalizationConfiguration_Of_Language()
        {
            //Arrange
            var type = typeof(EntityFrameworkCore.Configurations.TravelTypeConfiguration<Language>);

            //Act
            var configuration = new LanguageConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}