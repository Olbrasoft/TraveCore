using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Accommodation
{
    [TestFixture]
    internal class RealEStateDetailByAccommodationIdAndLanguageIdQueryTest
    {
        [Test]
        public void Instance_Is_ByAccommodationIdAndLanguageIdQuery_Of_AccommodationDetail()
        {
            //Arrange
            var type = typeof(ByRealEstateIdAndLanguageIdQuery<PropertyDetail>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Is_ByLanguageIdQuery_Of_AccommodationDetail()
        {
            //Arrange
            var type = typeof(ByLanguageIdQuery<PropertyDetail>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        private static RealEstateDetailByRealEstateIdAndLanguageIdQuery Query()
        {
            var providerMock = new Mock<IQueryDispatcher>();

            //Act
            var query = new RealEstateDetailByRealEstateIdAndLanguageIdQuery(providerMock.Object);
            return query;
        }

        [Test]
        public void Instance_Implement_Interface_IQueryOfAccommodationDetail()
        {
            //Arrange
            var dispatcherMock = new Mock<IQueryDispatcher>();

            //Act
            var query = new RealEstateDetailByRealEstateIdAndLanguageIdQuery(dispatcherMock.Object);

            //Assert
            Assert.IsInstanceOf<IQuery<PropertyDetail>>(query);
        }

        [Test]
        public void LanguageId()
        {
            //Arrange
            var dispatcherMock = new Mock<IQueryDispatcher>();
            var query = new RealEstateDetailByRealEstateIdAndLanguageIdQuery(dispatcherMock.Object)
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
            var query = new RealEstateDetailByRealEstateIdAndLanguageIdQuery(dispatcherMock.Object)
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