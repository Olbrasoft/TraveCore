using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Globalization;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Globalization
{
    internal class LanguageConfigurationTest
    {
        [Test]
        public void Instance_Is_GlobalizationConfiguration_Of_Language()
        {
            //Arrange
            var type = typeof(GlobalizationConfiguration<Language>);

            //Act
            var configuration = new LanguageConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}