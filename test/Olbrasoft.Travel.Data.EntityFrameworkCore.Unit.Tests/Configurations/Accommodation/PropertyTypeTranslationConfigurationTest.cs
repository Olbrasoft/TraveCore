using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Accommodation
{
    [TestFixture]
    internal class PropertyTypeTranslationConfigurationTest
    {
        [Test]
        public void Instance_Is_TranslationConfiguration_Of_PropertyTypeTranslation()
        {
            //Arrange
            var type = typeof(TranslationConfiguration<PropertyTypeTranslation>);

            //Act
            var configuration = new PropertyTypeTranslationConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}