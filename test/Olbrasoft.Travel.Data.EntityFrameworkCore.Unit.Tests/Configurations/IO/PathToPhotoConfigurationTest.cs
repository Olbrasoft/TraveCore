using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.IO;
using Olbrasoft.Travel.Data.IO;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.IO
{
    internal class PathToPhotoConfigurationTest
    {
        [Test]
        public void Instance_Is_RoutingConfiguration_Of_PathToPhoto()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<PathToPhoto>);

            //Act
            var configuration = new PathToPhotoConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}