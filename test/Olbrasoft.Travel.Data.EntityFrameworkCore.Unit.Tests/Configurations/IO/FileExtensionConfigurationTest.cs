using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.IO;
using Olbrasoft.Travel.Data.IO;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.IO
{
    [TestFixture]
    internal class FileExtensionConfigurationTest
    {
        [Test]
        public void Instance_Is_RoutingConfiguration_Of_FileExtension()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<FileExtension>);

            //Act
            var configuration = new FileExtensionConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}