using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Routing;
using Olbrasoft.Travel.Data.IO;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Repositories.Routing
{
    [TestFixture]
    internal class PathsToPhotosRepositoryTest
    {
        [Test]
        public void Instance_Is_RoutingRepository_Of_PathToPhoto()
        {
            //Arrange
            var type = typeof(TravelRepository<PathToPhoto>);
            var contextMock = new Mock<TravelDbContext>();

            //Act
            var repository = new PathsToPhotosRepository(contextMock.Object);

            //Assert
            Assert.IsInstanceOf(type, repository);
        }
    }
}