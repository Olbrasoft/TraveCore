using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Accommodation
{
    [TestFixture]
    public class RealEstatesSuggestionsQueryTest
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
            var terms = new[] { "Some Terms" };

            //Act
            query.Terms = terms;

            //Assert
            Assert.AreSame(terms, query.Terms);
        }

        private static RealEstatesSuggestionsQuery Query()
        {
            var dispatcherMock = new Mock<IQueryDispatcher>();
            var query = new RealEstatesSuggestionsQuery(dispatcherMock.Object);
            return query;
        }
    }
}