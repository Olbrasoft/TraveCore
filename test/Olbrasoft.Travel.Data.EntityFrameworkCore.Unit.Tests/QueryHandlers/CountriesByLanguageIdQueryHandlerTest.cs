using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    [TestFixture]
    internal class CountriesByLanguageIdQueryHandlerTest
    {
        [Test]
        public void Inherits_From_TravelQueryHandler_Of_IGeographyContext_Comma_GetCountriesByLanguageId_Comma_Country_Comma_IEnumerable_Of_CountryItem()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler<CountriesByLanguageIdQuery, Country,
                    IEnumerable<CountryItem>>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);

        }

        [Test]
        public void Instance_Is_QueryHandler_Of_GetCountriesByLanguageId_Comma_Country_Comma_IEnumerable_Of_CountryItem()
        {
            //Arrange
            var type = typeof(QueryHandler<CountriesByLanguageIdQuery, IQueryable<Country>, IEnumerable<CountryItem>>);


            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type,handler);
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
            Assert.IsInstanceOf<Task<IEnumerable<CountryItem>>>(result);

        }
        
        private static CountriesByLanguageIdQueryHandler Handler()
        {
            var contextMock = new Mock<TravelDbContext>();
            var projectorMock = new Mock<IProjection>();
            
            return new CountriesByLanguageIdQueryHandler(contextMock.Object,projectorMock.Object);
        }
    }
}