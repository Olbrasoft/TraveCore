using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Queries.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Geography
{
    [TestFixture]
    internal class CountriesByContinentIdAndLanguageIdQueryTest
    {
        [Test]
        public void Inherits_From_ByLanguageIdQuery_Of_IEnumerable_Of_CountryItem()
        {
            //Arrange
            var type = typeof(TranslationQuery<IEnumerable<CountryItemDto>>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void ContinentId_Get_Set()
        {
            //Arrange
            const int continentId = int.MinValue;
            var query = Query();
            query.ContinentId = continentId;

            //Act
            var result = query.ContinentId;

            //Assert
            Assert.IsTrue(result == continentId);
        }

        private static CountriesByContinentIdAndLanguageIdQuery Query()
        {
            var providerMock = new Mock<IQueryDispatcher>();

            var query = new CountriesByContinentIdAndLanguageIdQuery(providerMock.Object);
            return query;
        }
    }
}