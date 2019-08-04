using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Accommodation
{
    [TestFixture]
    internal class PropertyTranslationConfigurationTest
    {
        [Test]
        public void Instance_Is_TranslationConfiguration_Of_PropertyTranslation()
        {
            //Arrange
            var type = typeof(TranslationConfiguration<PropertyTranslation>);

            //Act
            var configuration = new PropertyTranslationConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}