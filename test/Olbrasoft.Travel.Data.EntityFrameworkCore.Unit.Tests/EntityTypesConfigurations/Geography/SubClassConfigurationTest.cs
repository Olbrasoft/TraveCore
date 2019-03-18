using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Geography;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Geography
{
    [TestFixture]
    internal class SubClassConfigurationTest
    {
        [Test]
        public void Instance_Is_Implement_TravelTypeConfiguration_Of_SubClass()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<Subclass>);

            //Act
            var configuration = new SubClassConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}