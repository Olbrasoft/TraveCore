using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Property
{
    [TestFixture]
    internal class ChainConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration_Of_Chain()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<Chain>);

            //Act
            var configuration = new ChainConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}