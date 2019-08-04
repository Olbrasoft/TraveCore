using Moq;
using NUnit.Framework;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Queries.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Accommodation
{
    public class PagedPropertyItemsByRegionIdTranslationQueryTest
    {
        [Test]
        public void Instance_Is_PagedPropertyItemsTranslationQuery()
        {
            //Arrange
            var type = typeof(PagedPropertyItemsTranslationQuery);

            //Act
            var query = Create();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void RegionId()
        {
            //Arrange
            const int regionId = 1976;
            var query = Create();

            //Act
            query.RegionId = regionId;

            //Assert
            Assert.AreEqual(regionId, query.RegionId);
        }

        private static PagedPropertyItemsByRegionIdTranslationQuery Create()
        {
            var providerMock = new Mock<IQueryDispatcher>();

            var query = new PagedPropertyItemsByRegionIdTranslationQuery(providerMock.Object);
            return query;
        }
    }
}