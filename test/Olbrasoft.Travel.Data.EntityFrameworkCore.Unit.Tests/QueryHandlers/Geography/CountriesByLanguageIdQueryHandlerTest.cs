using Moq;
using NUnit.Framework;
using Olbrasoft.Mapping;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Base.Objects.Geography;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Geography;
using Olbrasoft.Travel.Data.Queries.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers.Geography
{
    [TestFixture]
    internal class CountriesByLanguageIdQueryHandlerTest
    {
        [Test]
        public void Inherits_From_TravelQueryHandler_Of_IGeographyContext_Comma_GetCountriesByLanguageId_Comma_Country_Comma_IEnumerable_Of_CountryItem()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler<CountriesByLanguageIdQuery,
                    IEnumerable<CountryItemDto>, Country>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void Instance_Is_QueryHandler_Of_GetCountriesByLanguageId_Comma_Country_Comma_IEnumerable_Of_CountryItem()
        {
            //Arrange
            var type = typeof(QueryHandler<CountriesByLanguageIdQuery, IQueryable<Country>, IEnumerable<CountryItemDto>>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void HandleAsync_Return_Task_Of_IEnumerable_Of_CountryItem()
        {
            //Arrange
            var handler = Handler();
            var providerMock = new Mock<IQueryDispatcher>();
            var query = new CountriesByLanguageIdQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<CountryItemDto>>>(result);
        }

        private static CountriesByLanguageIdQueryHandler Handler()
        {
            var contextMock = new Mock<TravelDbContext>();
            var projectorMock = new Mock<IProjection>();

            return new CountriesByLanguageIdQueryHandler(projectorMock.Object, contextMock.Object);
        }
    }
}