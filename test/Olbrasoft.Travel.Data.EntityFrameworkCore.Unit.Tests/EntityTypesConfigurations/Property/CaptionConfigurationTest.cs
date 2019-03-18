using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Property
{
    [TestFixture]
    internal class CaptionConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration_Of_Caption()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<Caption>);

            //Act
            var configuration = new CaptionConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}