using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    [TestFixture]
    public class SuggestionsOfRegionByTermAndLanguageIdQueryTest
    {
        [Test]
        public void Instance_Is_ByLanguageIdQuery_Of_IEnumerable_Of_Suggestion()
        {
            //Arrange
            var type = typeof(ByLanguageIdQuery<IEnumerable<Suggestion>>);

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
            var terms = new[]{"Some Terms"};

            //Act
            query.Terms = terms;

            //Assert
            Assert.AreSame(terms, query.Terms);
        }

        private static SuggestionsOfRegionByTermAndLanguageIdQuery Query()
        {
            var dispatcherMock = new Mock<IQueryDispatcher>();

            var query = new SuggestionsOfRegionByTermAndLanguageIdQuery(dispatcherMock.Object);
            return query;
        }
    }
}