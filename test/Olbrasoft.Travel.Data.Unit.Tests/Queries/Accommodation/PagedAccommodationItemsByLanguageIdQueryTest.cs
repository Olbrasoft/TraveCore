using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Accommodation
{
    [TestFixture]
    internal class PagedAccommodationItemsByLanguageIdQueryTest
    {
        [Test]
        public void Instance_Is_ByLanguageIdQuery_Of_IResultWithTotalCount_Of_AccommodationItem()
        {
            //Arrange
            var type = typeof(TranslationQuery<IResultWithTotalCount<PropertyItem>>);
            var providerMock = new Mock<IQueryDispatcher>();

            //Act
            var query = new PagedPropertyItemsTranslationQuery(providerMock.Object);

            //Assert
            Assert.IsInstanceOf(type, query);
        }
    }
}