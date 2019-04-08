using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers.Accommodation
{
    [TestFixture]
    public class PropertiesSuggestionsByTermsTranslationQueryHandlerTest
    {
        [Test]
        public void Instance_Is_TravelQueryHandler_Of_()
        {
            //Arrange
            var type =
                typeof(QueryHandler<PropertiesSuggestionsByTermsTranslationQuery, PropertyTranslation,
                    IEnumerable<Transfer.Objects.SuggestionDto>>);
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
            var dispatcher = new Mock<IQueryDispatcher>();
            var query = new PropertiesSuggestionsByTermsTranslationQuery(dispatcher.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert

            Assert.IsInstanceOf(type, result);
        }

        private static PropertiesSuggestionsByTermsTranslationQueryHandler Handler()
        {
            var contextMock = new Mock<TravelDbContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new PropertiesSuggestionsByTermsTranslationQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }
    }
}