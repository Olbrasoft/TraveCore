using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Property;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Property
{
    [TestFixture]
    internal class TypeOfRoomConfigurationTest
    {
        [Test]
        public void Instance_Is_CreatorConfiguration_Of_TypeOfRoom()
        {
            //Arrange
            var type = typeof(CreatorConfiguration<TypeOfRoom>);

            //Act
            var configuration = new TypeOfRoomConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}