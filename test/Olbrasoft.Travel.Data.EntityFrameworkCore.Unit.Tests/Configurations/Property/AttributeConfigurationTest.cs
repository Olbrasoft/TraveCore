using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Property
{
    [TestFixture]
    internal class AttributeConfigurationTest
    {
        [Test]
        public void Instance_Is_CreatorConfiguration_Of_Attribute()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<Attribute>);

            //Act
            var configuration = new AttributeConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}