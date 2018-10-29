using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Property;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Property
{
    [TestFixture]
    internal class ChainConfigurationTest
    {
        [Test]
        public void Instance_Is_CreatorConfiguration_Of_Chain()
        {
            //Arrange
            var type = typeof(PropertyConfiguration<Chain>);

            //Act
            var configuration = new ChainConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}