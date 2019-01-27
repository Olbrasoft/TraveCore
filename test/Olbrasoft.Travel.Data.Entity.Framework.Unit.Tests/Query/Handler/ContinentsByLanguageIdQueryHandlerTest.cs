using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Entity.Framework.Query.Handler;
using Olbrasoft.Travel.Data.Entity.Geography;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Queries;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Query.Handler
{
    [TestFixture]
    internal class ContinentsByLanguageIdQueryHandlerTest
    {
        [Test]
        public void Inherits_From_TravelQueryHandler_Of_IGeographyContext_Comma_ContinentsByLanguageIdQuery_Comma_IQueryable_Of_TypeOfRegion_Comma_IEnumerable_Of_ContinentItem()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler<IGeographyContext, ContinentsByLanguageIdQuery, IQueryable<TypeOfRegion>,
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
            var type = typeof(QueryHandler<ContinentsByLanguageIdQuery, IQueryable<TypeOfRegion>, IEnumerable<ContinentItem>>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        private static ContinentsByLanguageIdQueryHandler Handler()
        {
            var contextMock = new Mock<IGeographyContext>();
            contextMock.Setup(p => p.TypesOfRegions).Returns(new Mock<DbSet<TypeOfRegion>>().Object);

            var projectorMock = new Mock<IProjection>();

            var handler = new ContinentsByLanguageIdQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }

        [Test]
        public void HandleAsync_Return_Task_Of_IEnumerable_Of_ContinentItem()
        {
            //Arrange
            var handler = Handler();
            var providerMock = new Mock<IProvider>();
            var query = new ContinentsByLanguageIdQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<ContinentItem>>>(result);
        }
    }
}