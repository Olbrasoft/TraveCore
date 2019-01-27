using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Queries;
using Olbrasoft.Travel.Data.Entity.Framework.Query.Handler;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Query.Handler
{
    [TestFixture]
    internal class AttributesByAccommodationIdAndLanguageIdQueryHandlerTest
    {
        [Test]
        public void MyTestMethod()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler<IGlobalizationContext, AttributesByAccommodationIdAndLanguageIdQuery,
                    IQueryable<AccommodationToAttribute>, IEnumerable<Transfer.Object.Attribute>>);

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

            var providerMock = new Mock<IProvider>();
            var query = new AttributesByAccommodationIdAndLanguageIdQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query, default(CancellationToken));

            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<Attribute>>>(result);
        }

        private static AttributesByAccommodationIdAndLanguageIdQueryHandler Handler()
        {
            var contextMock = new Mock<IGlobalizationContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new AttributesByAccommodationIdAndLanguageIdQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }
    }
} 