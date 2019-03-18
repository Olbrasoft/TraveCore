using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Accommodation
{
    [TestFixture]
    internal class LocalizedCaptionConfigurationTest
    {
        [Test]
        public void Instance_Is_LocalizedConfiguration_Of_LocalizedCaption()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<LocalizedCaption>);

            //Act
            var configuration = new LocalizedCaptionConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}