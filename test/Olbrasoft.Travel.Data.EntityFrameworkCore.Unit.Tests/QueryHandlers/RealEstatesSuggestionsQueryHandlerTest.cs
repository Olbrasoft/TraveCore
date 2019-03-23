using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    [TestFixture]
    public class RealEstatesSuggestionsQueryHandlerTest
    {
        [Test]
        public void MyTestMethod()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler<RealEstatesSuggestionsQuery, LocalizedRealEstate,
                    IEnumerable<Suggestion>>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void HandleAsync_Returns_Task_Of_IEnumerable_Of_Suggestion()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<Suggestion>>);
            var handler = Handler();
            var dispatcher = new Mock<IQueryDispatcher>();
            var query = new RealEstatesSuggestionsQuery(dispatcher.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert

            Assert.IsInstanceOf(type, result);
        }

        private static RealEstatesSuggestionsQueryHandler Handler()
        {
            var contextMock = new Mock<TravelDbContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new RealEstatesSuggestionsQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }
    }
}