using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Property;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Property
{
    [TestFixture]
    internal class TypeOfAccommodationConfigurationTest
    {
        [Test]
        public void Instance_Is_PropertyConfiguration_Of_TypeOfAccommodation()
        {
            //Arrange
            var type = typeof(PropertyConfiguration<TypeOfAccommodation>);

            //Act
            var configuration = new TypeOfAccommodationConfiguration();

            //Assert
            Assert.IsInstanceOf(type,configuration);

        }
    }
}
