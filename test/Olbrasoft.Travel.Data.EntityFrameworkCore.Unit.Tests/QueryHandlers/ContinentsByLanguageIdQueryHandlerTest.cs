using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
    internal class ContinentsByLanguageIdQueryHandlerTest
    {
        [Test]
        public void Inherits_From_TravelQueryHandler_Of_IGeographyContext_Comma_ContinentsByLanguageIdQuery_Comma_IQueryable_Of_TypeOfRegion_Comma_IEnumerable_Of_ContinentItem()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler< ContinentsByLanguageIdQuery, Subtype,
                    IEnumerable<ContinentItem>>);
            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void Inherits_From_QueryHandler_Of_ContinentsByLanguageIdQuery_Comma_TypeOfRegion_Comma_IEnumerable_Of_ContinentItem()
        {
            //Arrange
            var type = typeof(QueryHandler<ContinentsByLanguageIdQuery, IQueryable<Subtype>, IEnumerable<ContinentItem>>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        private static ContinentsByLanguageIdQueryHandler Handler()
        {
            var contextMock = new Mock<TravelDbContext>();
            contextMock.Setup(p => p.Set<Subtype>()).Returns(new Mock<DbSet<Subtype>>().Object);

            var projectorMock = new Mock<IProjection>();

            var handler = new ContinentsByLanguageIdQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }

        [Test]
        public void HandleAsync_Return_Task_Of_IEnumerable_Of_ContinentItem()
        {
            //Arrange
            var handler = Handler();
            var providerMock = new Mock<IQueryDispatcher>();
            var query = new ContinentsByLanguageIdQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<ContinentItem>>>(result);
        }
    }
}