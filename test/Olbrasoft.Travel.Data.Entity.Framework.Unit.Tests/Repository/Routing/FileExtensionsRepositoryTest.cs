using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Framework.Repository;
using Olbrasoft.Travel.Data.Entity.Framework.Repository.Routing;
using Olbrasoft.Travel.Data.Entity.Routing;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Repository.Routing
{
    [TestFixture]
    internal class FileExtensionsRepositoryTest
    {
        [Test]
        public void Instance_Is_RoutingRepository_Of_FileExtension()
        {
            //Arrange
            var type = typeof(RoutingRepository<FileExtension>);
            var contextMock = new Mock<RoutingDatabaseContext>();

            //Act
            var repository = new FilesExtensionsRepository(contextMock.Object);

            //Assert
            Assert.IsInstanceOf(type, repository);
        }
    }
}