using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Geography;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Geography
{
    [TestFixture]
    internal class SubClassConfigurationTest
    {
        [Test]
        public void Instance_Is_Implement_GeographyConfiguration_Of_SubClass()
        {
            //Arrange
            var type = typeof(GeographyConfiguration<SubClass>);

            //Act
            var configuration = new SubClassConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}