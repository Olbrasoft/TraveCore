using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Entity.Framework.Query.Handler;
using Olbrasoft.Travel.Data.Entity.Geography;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Query.Handler
{
    [TestFixture]
    internal class CountriesByLanguageIdQueryHandlerTest
    {
        [Test]
        public void Inherits_From_TravelQueryHandler_Of_IGeographyContext_Comma_GetCountriesByLanguageId_Comma_Country_Comma_IEnumerable_Of_CountryItem()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler<IGeographyContext, CountriesByLanguageIdQuery, IQueryable<Country>,
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
            var providerMock = new Mock<IProvider>();
            var query = new CountriesByLanguageIdQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<CountryItem>>>(result);

        }
        
        private static CountriesByLanguageIdQueryHandler Handler()
        {
            var contextMock = new Mock<IGeographyContext>();
            var projectorMock = new Mock<IProjection>();
            
            return new CountriesByLanguageIdQueryHandler(contextMock.Object,projectorMock.Object);
        }
    }
}