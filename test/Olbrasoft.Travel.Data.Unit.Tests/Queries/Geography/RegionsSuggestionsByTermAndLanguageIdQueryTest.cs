using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Queries.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Geography
{
    [TestFixture]
    public class RegionsSuggestionsByTermAndLanguageIdQueryTest
    {
        [Test]
        public void Instance_Is_ByLanguageIdQuery_Of_IEnumerable_Of_Suggestion()
        {
            //Arrange
            var type = typeof(TranslationQuery<IEnumerable<Data.Transfer.Objects.SuggestionDto>>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Terms()
        {
            //Arrange
            var query = Query();
            var terms = new[] { "Some Terms" };

            //Act
            query.Terms = terms;

            //Assert
            Assert.AreSame(terms, query.Terms);
        }

        private static RegionsSuggestionsByTermsTranslationQuery Query()
        {
            var dispatcherMock = new Mock<IQueryDispatcher>();

            var query = new RegionsSuggestionsByTermsTranslationQuery(dispatcherMock.Object);
            return query;
        }
    }
}