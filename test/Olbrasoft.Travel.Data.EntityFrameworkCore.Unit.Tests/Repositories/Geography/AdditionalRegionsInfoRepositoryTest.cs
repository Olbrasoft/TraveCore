using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Geography;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Repositories.Geography
{
    [TestFixture]
    internal class AdditionalRegionsInfoRepositoryTest
    {
        [Test]
        public void Instance_Is_GeographyRepository_Of_CreatorInfo()
        {
            //Arrange
            var type = typeof(TravelRepository<Country>);
            var context = new Mock<TravelDbContext>();

            //Act
            var repository = new AdditionalRegionsInfoRepository<Country>(context.Object);

            //Assert
            Assert.IsInstanceOf(type, repository);
        }
    }
}