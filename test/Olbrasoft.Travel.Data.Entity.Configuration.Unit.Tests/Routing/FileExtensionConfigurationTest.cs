using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Routing;
using Olbrasoft.Travel.Data.Entity.Routing;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Routing
{
    [TestFixture]
    internal class FileExtensionConfigurationTest
    {
        [Test]
        public void Instance_Is_RoutingConfiguration_Of_FileExtension()
        {
            //Arrange
            var type = typeof(RoutingConfiguration<FileExtension>);

            //Act
            var configuration = new FileExtensionConfiguration();
            
            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}