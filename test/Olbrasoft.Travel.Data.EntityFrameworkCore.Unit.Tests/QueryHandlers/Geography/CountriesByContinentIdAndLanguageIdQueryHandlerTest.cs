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
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers.Geography
{
    [TestFixture]
    internal class CountriesByContinentIdAndLanguageIdQueryHandlerTest
    {
        [Test]
        public void Inherits_From_TravelQueryHandler_Of_IGeographyContext_Comma_CountriesByContinentIdAndLanguageIdQuery_Comma_Country_Comma_IEnumerable_Of_CountryItem()
        {
            //Arrange
            var type =
                typeof(QueryHandler< CountriesByContinentIdAndLanguageIdQuery, Country,
                    IEnumerable<CountryItemDto>>);

            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);

        }

        private static CountriesByContinentIdAndLanguageIdQueryHandler Handler()
        {
            var contextMock = new Mock<TravelDbContext>();
            var projectorMock = new Mock<IProjection>();

            //Act
            var handler = new CountriesByContinentIdAndLanguageIdQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }

        [Test]
        public void HandleAsync_Return_Task_Of_IEnumerable_Of_CountryItem()
        {
            //Arrange
            var handler = Handler();
            var providerMock = new Mock<IQueryDispatcher>();
            var query = new CountriesByContinentIdAndLanguageIdQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<CountryItemDto>>>(result);

        }


    }
}