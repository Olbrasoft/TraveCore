using Moq;
using NUnit.Framework;
using Olbrasoft.Paging;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Accommodation
{
    [TestFixture]
    internal class PagedPropertyItemsTranslationQueryTest
    {
        [Test]
        public void Instance_Is_TranslationQuery_Of_IResultWithTotalCount_Of_AccommodationItem()
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