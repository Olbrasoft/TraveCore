using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Geography;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Geography
{
    [TestFixture]
    internal class SubtypeConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration_of_TypeOfRegion()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<Subtype>);

            //Act
            var configuration = new SubtypeConfiguration();

            //Assert
            Assert.IsInstanceOf(type,configuration);
        }
    }
}
