using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Geography;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Repositories.Geography
{
    [TestFixture]
    internal class RegionsRepositoryTest
    {
        [Test]
        public void Instance_Is_GeographyRepository_Of_Region()
        {
            //Arrange
            var type = typeof(TravelRepository<Region>);
            var repository = GetRepository();

            //Assert
            Assert.IsInstanceOf(type, repository);
        }

        private static RegionsRepository GetRepository()
        {
            var contextMock = new Mock<TravelDbContext>();

            //Act
            var repository = new RegionsRepository(contextMock.Object);
            return repository;
        }
    }
}