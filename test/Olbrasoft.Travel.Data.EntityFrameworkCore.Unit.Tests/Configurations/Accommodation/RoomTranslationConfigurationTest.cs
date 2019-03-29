using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Accommodation
{
    [TestFixture]
    internal class RoomTranslationConfigurationTest
    {
        [Test]
        public void Instance_Is_TranslationConfiguration_Of_RoomTranslation()
        {
            //Arrange
            var type = typeof(TranslationConfiguration<RoomTranslation>);

            //Act
            var configuration = new RoomTranslationConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}