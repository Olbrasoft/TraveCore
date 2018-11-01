using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Globalization;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Globalization
{
    [TestFixture]
    internal class LocalizedAttributeConfigurationTest
    {
        [Test]
        public void Instance_Is_LocalizedConfiguration_Of_LocalizedAttribute()
        {
            //Arrange
            var type = typeof(LocalizedConfiguration<LocalizedAttribute>);

            //Act
            var configuration = new LocalizedAttributeConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}