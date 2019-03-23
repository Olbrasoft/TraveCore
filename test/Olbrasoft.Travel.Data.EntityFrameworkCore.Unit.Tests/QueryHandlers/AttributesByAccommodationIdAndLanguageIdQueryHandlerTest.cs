using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Attribute = Olbrasoft.Travel.Data.Transfer.Objects.Attribute;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    [TestFixture]
    internal class AttributesByAccommodationIdAndLanguageIdQueryHandlerTest
    {
        [Test]
        public void MyTestMethod()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler< AttributesByRealEstateIdAndLanguageIdQuery,
                    RealEstateToAttribute, IEnumerable<Attribute>>);

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
            var query = new AttributesByRealEstateIdAndLanguageIdQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query, default(CancellationToken));

            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<Attribute>>>(result);
        }

        private static AttributesByAccommodationIdAndLanguageIdQueryHandler Handler()
        {
            var contextMock = new Mock<TravelDbContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new AttributesByAccommodationIdAndLanguageIdQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }
    }
} 