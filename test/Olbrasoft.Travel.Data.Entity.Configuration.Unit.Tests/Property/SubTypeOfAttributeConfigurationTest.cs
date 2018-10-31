using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Property;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Property
{
    [TestFixture]
    internal class SubTypeOfAttributeConfigurationTest
    {
        [Test]
        public void Instance_Is_NameConfiguration_Of_SubTypeOfAttribute()
        {
            //Arrange
            var type = typeof(NameConfiguration<SubTypeOfAttribute>);

            //Act
            var configuration = new SubTypeOfAttributeConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}