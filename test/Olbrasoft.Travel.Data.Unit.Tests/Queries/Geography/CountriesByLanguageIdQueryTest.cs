using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Queries.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Geography
{
    [TestFixture]
    internal class CountriesByLanguageIdQueryTest
    {
        [Test]
        public void Instance_Is_ByLanguageIdQuery_Of_IEnumerable_Of_CountryItem()
        {
            //Arrange
            var type = typeof(ByLanguageIdQuery<IEnumerable<CountryItemDto>>);

            //Act
            var query = GetCountriesByLanguageId();

            //Assert
            Assert.IsInstanceOf(type, query);

        }

        [Test]
        public void Instance_Is_QueryWithDependentProvider_Of_IEnumerable_Of_CountryItem()
        {
            //Arrange
            var type = typeof(Query<IEnumerable<CountryItemDto>>);

            //Act
            var query = GetCountriesByLanguageId();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Is_Implement_Interface_IQuery_Of_IEnumerable_Of_CountryItem()
        {
            //Arrange
            var type = typeof(IQuery<IEnumerable<CountryItemDto>>);

            //Act
            var query = GetCountriesByLanguageId();
            
            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void GetSetLanguageId()
        {
            //Arrange
            const int languageId = 1033;
            var query = GetCountriesByLanguageId();

            //Act 
            query.LanguageId = languageId;

            //Assert
            Assert.IsTrue(languageId == query.LanguageId);
        }

        private static CountriesByLanguageIdQuery GetCountriesByLanguageId()
        {
            var providerMock = new Mock<IQueryDispatcher>();

            //Act
            var query = new CountriesByLanguageIdQuery(providerMock.Object);
            return query;
        }
    }
}