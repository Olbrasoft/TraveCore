using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Property
{
    [TestFixture]
    internal class AttributeConfigurationTest
    {
        [Test]
        public void Instance_Is_CreatorConfiguration_Of_Attribute()
        {
            //Arrange
            var type = typeof(CreatorConfiguration<Entity.Property.Attribute>);

            //Act
            var configuration = new AttributeConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}