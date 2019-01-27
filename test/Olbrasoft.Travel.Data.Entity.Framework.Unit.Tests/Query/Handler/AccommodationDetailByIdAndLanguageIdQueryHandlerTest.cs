using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Queries;
using Olbrasoft.Travel.Data.Entity.Framework.Query.Handler;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Query.Handler
{
    [TestFixture]
    internal class AccommodationDetailByIdAndLanguageIdQueryHandlerTest
    {
        [Test]
        public void MyTestMethod()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler<IPropertyContext, AccommodationDetailByAccommodationIdAndLanguageIdQuery,
                    IQueryable<Property.Accommodation>,
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
                typeof(QueryHandler<AccommodationDetailByAccommodationIdAndLanguageIdQuery, IQueryable<Property.Accommodation>,
                    AccommodationDetail>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type,handler);
        }

        private static AccommodationDetailByIdAndLanguageIdQueryHandler Handler()
        {
            var contextMock = new Mock<IPropertyContext>();
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
            var providerMock = new Mock<IProvider>();
            var query = new AccommodationDetailByAccommodationIdAndLanguageIdQuery(providerMock.Object);
            
            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf(type,result);

        }

    }
}