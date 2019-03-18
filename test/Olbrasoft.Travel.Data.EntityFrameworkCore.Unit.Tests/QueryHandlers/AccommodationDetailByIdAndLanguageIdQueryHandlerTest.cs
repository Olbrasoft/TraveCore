using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Objects;
using System.Linq;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    [TestFixture]
    internal class AccommodationDetailByIdAndLanguageIdQueryHandlerTest
    {
        [Test]
        public void MyTestMethod()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler<AccommodationDetailByAccommodationIdAndLanguageIdQuery, RealEstate,
                    AccommodationDetail>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void Inherits_From_PropertyQueryHandler_AccommodationDetailByIdAndLanguageIdQuery_Comma_IQueryable_Of_Accommodation_Comma_AccommodationDetail()
        {
            //Arrange
            var type =
                typeof(QueryHandler<AccommodationDetailByAccommodationIdAndLanguageIdQuery, IQueryable<RealEstate>,
                    AccommodationDetail>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        private static AccommodationDetailByIdAndLanguageIdQueryHandler Handler()
        {
            var contextMock = new Mock<TravelDbContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new AccommodationDetailByIdAndLanguageIdQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }

        [Test]
        public void HandleAsync_Return_Task_Of_AccommodationDetail()
        {
            //Arrange
            var type = typeof(Task<AccommodationDetail>);
            var handler = Handler();
            var providerMock = new Mock<IQueryDispatcher>();
            var query = new AccommodationDetailByAccommodationIdAndLanguageIdQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf(type, result);
        }
    }
}