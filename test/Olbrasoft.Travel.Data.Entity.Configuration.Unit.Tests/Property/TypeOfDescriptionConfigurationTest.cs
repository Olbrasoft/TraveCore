using NUnit.Framework;
using NUnit.Framework.Internal;
using Olbrasoft.Travel.Data.Entity.Model.Configuration.Property;
using Olbrasoft.Travel.Data.Entity.Model.Property;

namespace Olbrasoft.Travel.Data.Entity.Model.Configuration.Unit.Tests.Property
{
    [TestFixture]
    internal class TypeOfDescriptionConfigurationTest
    {
        [Test]
        public void Instance_Is_NameConfiguration_Of_TypeOfDescription()
        {
            //Arrange
            var type = typeof(NameConfiguration<TypeOfDescription>);

            //Act
            var configuration = new TypeOfDescriptionConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}