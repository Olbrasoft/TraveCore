using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers.Accommodation
{
    [TestFixture]
    internal class AttributesByAccommodationIdAndLanguageIdQueryHandlerTest
    {
        [Test]
        public void MyTestMethod()
        {
            //Arrange
            var type =
                typeof(QueryHandler< AttributesByPropertyIdAndLanguageIdQuery,
                    PropertyToAttribute, IEnumerable<AttributeDto>>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type,handler);
        }


        [Test]
        public void HandleAsync()
        {
            //Arrange
            var handler = Handler();

            var providerMock = new Mock<IQueryDispatcher>();
            var query = new AttributesByPropertyIdAndLanguageIdQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query, default(CancellationToken));

            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<AttributeDto>>>(result);
        }

        private static AttributesByPropertyIdAndLanguageIdQueryHandler Handler()
        {
            var contextMock = new Mock<TravelDbContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new AttributesByPropertyIdAndLanguageIdQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }
    }
} 