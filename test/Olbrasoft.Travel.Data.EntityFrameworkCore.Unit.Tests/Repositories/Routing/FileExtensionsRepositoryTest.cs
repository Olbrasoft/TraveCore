using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Routing;
using Olbrasoft.Travel.Data.IO;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Repository.Routing
{
    [TestFixture]
    internal class FileExtensionsRepositoryTest
    {
        [Test]
        public void Instance_Is_RoutingRepository_Of_FileExtension()
        {
            //Arrange
            var type = typeof(TravelRepository<FileExtension>);
            var contextMock = new Mock<TravelDbContext>();

            //Act
            var repository = new FilesExtensionsRepository(contextMock.Object);

            //Assert
            Assert.IsInstanceOf(type, repository);
        }
    }
}