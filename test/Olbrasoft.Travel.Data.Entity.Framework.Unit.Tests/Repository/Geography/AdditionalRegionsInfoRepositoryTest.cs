using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Framework.Repository;
using Olbrasoft.Travel.Data.Entity.Framework.Repository.Geography;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Repository.Geography
{
    [TestFixture]
    internal class AdditionalRegionsInfoRepositoryTest
    {
        [Test]
        public void Instance_Is_GeographyRepository_Of_CreatorInfo()
        {
            //Arrange
            var type = typeof(GeographyRepository<Entity.Geography.Country>);
            var context = new Mock<GeographyDatabaseContext>();

            //Act
            var repository = new AdditionalRegionsInfoRepository<Entity.Geography.Country>(context.Object);

            //Assert
            Assert.IsInstanceOf(type, repository);
        }
    }
}