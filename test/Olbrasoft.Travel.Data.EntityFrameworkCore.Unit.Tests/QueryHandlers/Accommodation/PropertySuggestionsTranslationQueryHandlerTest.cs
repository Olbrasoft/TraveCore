using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers.Accommodation
{
    public class PropertySuggestionsTranslationQueryHandlerTest
    {
        [Test]
        public void Instance_Is_SuggestionsTranslationQueryHandler_Of_PropertySuggestionTranslationQuery()
        {
            //Arrange
            var type = typeof(TravelQueryHandler<PropertySuggestionsTranslationQuery,PropertyTranslation,IEnumerable<SuggestionDto>>);

            //Act
            var handler = Create();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        private static PropertySuggestionsTranslationQueryHandler Create()
        {
            var contextMock = new Mock<TravelDbContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new PropertySuggestionsTranslationQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }

        [Test]
        public void HandleAsync()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<SuggestionDto>>);
            var handler = Create();

            var dispatcherMock = new Mock<IQueryDispatcher>();
            var query = new PropertySuggestionsTranslationQuery(dispatcherMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf(type, result);
        }
    }
}