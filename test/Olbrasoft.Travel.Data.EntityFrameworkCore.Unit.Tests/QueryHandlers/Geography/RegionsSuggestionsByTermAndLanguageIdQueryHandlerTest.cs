using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Geography;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Queries.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers.Geography
{
    [TestFixture]
    public class RegionsSuggestionsByTermAndLanguageIdQueryHandlerTest
    {
        private static RegionsSuggestionsByTermsAndLanguageIdQueryHandler Handler()
        {
            var contextMock = new Mock<TravelDbContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new RegionsSuggestionsByTermsAndLanguageIdQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }

        [Test]
        public void Instance_Is_TravelQueryHandler_Of_SuggestionsOfRegionByTermAndLanguageIdQuery_Comma_Region_Comma_IEnumerable_Of_Suggestion()
        {
            //Arrange
            var type =
                typeof(QueryHandler<RegionsSuggestionsByTermsTranslationQuery, Region, IEnumerable<Transfer.Objects.SuggestionDto>>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void HandleAsync_Returns_Task_Of_IEnumerable_Of_Suggestion()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<Transfer.Objects.SuggestionDto>>);
            var handler = Handler();

            var dispatcherMock = new Mock<IQueryDispatcher>();
            var query = new RegionsSuggestionsByTermsTranslationQuery(dispatcherMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf(type, result);
        }
    }
}