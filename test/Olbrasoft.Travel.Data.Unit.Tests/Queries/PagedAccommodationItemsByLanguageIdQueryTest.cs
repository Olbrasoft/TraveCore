using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    [TestFixture]
    internal class PagedAccommodationItemsByLanguageIdQueryTest
    {
        [Test]
        public void Instance_Is_ByLanguageIdQuery_Of_IResultWithTotalCount_Of_AccommodationItem()
        {
            //Arrange
            var type = typeof(ByLanguageIdQuery<IResultWithTotalCount<AccommodationItem>>);
            var providerMock = new Mock<IQueryDispatcher>();
            
            //Act
            var query = new PagedAccommodationItemsByLanguageIdQuery(providerMock.Object);

            //Assert
            Assert.IsInstanceOf(type,query);

        }
    }
}