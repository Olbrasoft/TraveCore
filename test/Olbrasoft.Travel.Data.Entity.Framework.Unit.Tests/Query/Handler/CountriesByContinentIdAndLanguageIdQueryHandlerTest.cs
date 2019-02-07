using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Entity.Framework.Query.Handler;
using Olbrasoft.Travel.Data.Entity.Geography;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Query.Handler
{
    [TestFixture]
    internal class CountriesByContinentIdAndLanguageIdQueryHandlerTest
    {
        [Test]
        public void Inherits_From_TravelQueryHandler_Of_IGeographyContext_Comma_CountriesByContinentIdAndLanguageIdQuery_Comma_Country_Comma_IEnumerable_Of_CountryItem()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler<IGeographyContext, CountriesByContinentIdAndLanguageIdQuery, IQueryable<Country>,
                    IEnumerable<CountryItem>>);

            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);

        }

        private static CountriesByContinentIdAndLanguageIdQueryHandler Handler()
        {
            var contextMock = new Mock<IGeographyContext>();
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
            var providerMock = new Mock<IProvider>();
            var query = new CountriesByContinentIdAndLanguageIdQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<CountryItem>>>(result);

        }


    }
}