using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Objects;
using System.Collections.Generic;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Queries.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Accommodation
{
    public class PropertySuggestionsTranslationQueryTest
    {
        [Test]
        public void Instance_Is_SuggestionsTranslationQuery()
        {
            //Arrange
            var type = typeof(SuggestionsTranslationQuery);

            //Act
            var query = Create();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Is_ByLanguageIdQuery_Of_IEnumerable_Of_Suggestion()
        {
            //Arrange
            var type = typeof(TranslationQuery<IEnumerable<SuggestionDto>>);

            //Act
            var query = Create();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Term()
        {
            //Arrange
            const string term = "Awesome Term";
            var query = Create();

            //Act
            query.Term = term;

            //Assert
            Assert.AreEqual(term, query.Term);
        }

        private static PropertySuggestionsTranslationQuery Create()
        {
            var dispatcherMock = new Mock<IQueryDispatcher>();

            var query = new PropertySuggestionsTranslationQuery(dispatcherMock.Object);
            return query;
        }
    }
}