using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Localization;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Localization
{
    internal class LanguageConfigurationTest
    {
        [Test]
        public void Instance_Is_GlobalizationConfiguration_Of_Language()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<Language>);

            //Act
            var configuration = new LanguageConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}