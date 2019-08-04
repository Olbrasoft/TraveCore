using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Accommodation
{
    [TestFixture]
    internal class DescriptionTranslationConfigurationTest
    {
        [Test]
        public void Instance_Is_TranslationConfiguration_Of_DescriptionTranslation()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<DescriptionTranslation>);

            //Act
            var configuration = new DescriptionTranslationConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }

        [Test]
        public void Instance_Is_PropertyConfiguration_Of_Description()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<DescriptionTranslation>);

            //Act
            var configuration = new DescriptionTranslationConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}