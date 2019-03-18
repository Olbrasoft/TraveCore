using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Repositories.Accommodation
{
    [TestFixture]
    internal class PhotosRepositoryTest
    {
        [Test]
        public void Instance_Is_PropertyRepository_Of_PhotoOfAccommodation()
        {
            //Arrange
            var type = typeof(TravelRepository<Photo>);
            var contextMock = new Mock<TravelDbContext>();

            //Act
            var repository = new PhotosRepository(contextMock.Object);

            //Assert
            Assert.IsInstanceOf(type, repository);
        }
    }
}