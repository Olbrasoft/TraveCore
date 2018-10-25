using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Framework.Repository.Geography;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Repository.Geography
{
    [TestFixture]
    internal class RegionsToTypesRepositoryTest
    {
        [Test]
        public void Instance_Is_ManyToManyRepository_Of_RegionToType()
        {
            //Arrange
            var type = typeof(ManyToManyRepository<RegionToType>);
            var contextMock = new Mock<GeographyDatabaseContext>();

            //Act
            var repository = new RegionsToTypesRepository(contextMock.Object);

            //Assert
            Assert.IsInstanceOf(type, repository);
        }
    }
}