using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    [TestFixture]
    internal class AccommodationDetailByAccommodationIdAndLanguageIdQueryTest
    {

        [Test]
        public void Instance_Is_ByAccommodationIdAndLanguageIdQuery_Of_AccommodationDetail()
        {
            //Arrange
            var type = typeof(ByAccommodationIdAndLanguageIdQuery<AccommodationDetail>);

            //Act
            var query = Query();
            
            //Assert
            Assert.IsInstanceOf(type,query);
        }

        [Test]
        public void Instance_Is_ByLanguageIdQuery_Of_AccommodationDetail()
        {
            //Arrange
            var type = typeof(ByLanguageIdQuery<AccommodationDetail>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        private static AccommodationDetailByAccommodationIdAndLanguageIdQuery Query()
        {
            var providerMock = new Mock<IQueryDispatcher>();

            //Act
            var query = new AccommodationDetailByAccommodationIdAndLanguageIdQuery(providerMock.Object);
            return query;
        }

        [Test]
        public void Instance_Implement_Interface_IQueryOfAccommodationDetail()
        {
            //Arrange
            var dispatcherMock = new Mock<IQueryDispatcher>();

            //Act
            var query = new AccommodationDetailByAccommodationIdAndLanguageIdQuery(dispatcherMock.Object);

            //Assert
            Assert.IsInstanceOf<IQuery<AccommodationDetail>>(query);
        }

        [Test]
        public void LanguageId()
        {
            //Arrange
            var dispatcherMock = new Mock<IQueryDispatcher>();
            var query = new AccommodationDetailByAccommodationIdAndLanguageIdQuery(dispatcherMock.Object)
            {
                LanguageId = 1033,
            };

            //Act
            var result = query.LanguageId;

            //Assert
            Assert.IsTrue(result == 1033);
        }

        [Test]
        public void Id()
        {
            //Arrange
            var dispatcherMock = new Mock<IQueryDispatcher>();
            var query = new AccommodationDetailByAccommodationIdAndLanguageIdQuery(dispatcherMock.Object)
            {
                AccommodationId = 42,
            };

            //Act
            var result = query.AccommodationId;

            //Assert
            Assert.IsTrue(result == 42);
        }
    }
}