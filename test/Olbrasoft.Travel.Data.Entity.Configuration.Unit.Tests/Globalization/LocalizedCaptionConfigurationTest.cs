using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Globalization;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Globalization
{
    [TestFixture]
    internal class LocalizedCaptionConfigurationTest
    {
        [Test]
        public void Instance_Is_LocalizedConfiguration_Of_LocalizedCaption()
        {
            //Arrange
            var type = typeof(LocalizedConfiguration<LocalizedCaption>);

            //Act
            var configuration = new LocalizedCaptionConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}