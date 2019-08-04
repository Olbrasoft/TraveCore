using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Geography;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Geography;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Geography
{
    [TestFixture]
    internal class RegionTranslationConfigurationTest
    {
        [Test]
        public void Instance_Is_TranslationConfiguration_Of_RegionTranslation()
        {
            //Arrange
            var type = typeof(TranslationConfiguration<RegionTranslation>);

            //Act
            var configuration = new RegionTranslationConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}