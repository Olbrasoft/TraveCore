using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.IO;
using Olbrasoft.Travel.Data.IO;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.IO
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