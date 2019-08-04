using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Property
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