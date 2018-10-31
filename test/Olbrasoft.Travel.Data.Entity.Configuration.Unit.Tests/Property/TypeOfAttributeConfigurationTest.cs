using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Property;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Property
{
    [TestFixture]
    internal class TypeOfAttributeConfigurationTest
    {
        [Test]
        public void Instance_Is_NameConfiguration_Of_TypeOfAttribute()
        {
            //Arrange
            var type = typeof(NameConfiguration<TypeOfAttribute>);

            //Act
            var configuration = new TypeOfAttributeConfiguration();

            //Assert
            Assert.IsInstanceOf(type,configuration);
        }
    }
}