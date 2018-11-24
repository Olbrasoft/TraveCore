using NUnit.Framework;
using NUnit.Framework.Internal;
using Olbrasoft.Travel.Data.Entity.Configuration.Geography;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Geography
{
    [TestFixture()]
    internal class ContinentConfigurationTest
    {
        [Test]
        public void Instance_Is_GeographyConfiguration_Of_Continent()
        {
            //Arrange
            var type = typeof(GeographyConfiguration<Continent>);

            //Act
            var configuration = new ContinentConfiguration();

            //Assert
            Assert.IsInstanceOf(type,configuration);
        }
    }
}