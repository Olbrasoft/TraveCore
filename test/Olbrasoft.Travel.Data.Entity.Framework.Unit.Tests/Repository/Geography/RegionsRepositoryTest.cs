using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Framework.Repository;
using Olbrasoft.Travel.Data.Entity.Framework.Repository.Geography;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Repository.Geography
{
    [TestFixture]
    internal class RegionsRepositoryTest
    {
        [Test]
        public void Instance_Is_GeographyRepository_Of_Region()
        {
            //Arrange
            var type = typeof(GeographyRepository<Region>);
            var repository = GetRepository();

            //Assert
            Assert.IsInstanceOf(type, repository);
        }

        private static RegionsRepository GetRepository()
        {
            var contextMock = new Mock<GeographyDatabaseContext>();

            //Act
            var repository = new RegionsRepository(contextMock.Object);
            return repository;
        }
    }
}