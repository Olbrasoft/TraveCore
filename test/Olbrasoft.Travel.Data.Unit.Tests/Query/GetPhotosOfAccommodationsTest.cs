using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;
using System.Linq;
using Olbrasoft.Travel.Data.Query;

namespace Olbrasoft.Travel.Data.Unit.Tests.Query
{
    [TestFixture]
    internal class GetPhotosOfAccommodationsTest
    {
        [Test]
        public void Instance_Implement_Interface_IQuery_Of_IEnumerable_Of_AccommodationPhoto()
        {
            //Arrange
            var type = typeof(IQuery<IEnumerable<AccommodationPhoto>>);

            //Act
            var query = CreateQuery();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Is_QueryWithDependentDispatcher_Of_IEnumerable_OfAccommodationPhoto()
        {
            //Arrange
            var type = typeof(QueryWithDependentProvider<IEnumerable<AccommodationPhoto>>);

            //Act
            var query = CreateQuery();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void AccommodationIds()
        {
            //Arrange
            var q = CreateQuery();
            q.AccommodationIds = new[] {1,2,3};

            //Act
            var ids = q.AccommodationIds;

            //Assert
            Assert.IsTrue(ids.First() ==1);


        }


        [Test]
        public void OnlyDefaultPhotos()
        {
            //Arrange
            var q = CreateQuery();

            //Act
            q.OnlyDefaultPhotos = true;
            
            //Assert
            Assert.IsTrue(q.OnlyDefaultPhotos);
        }


        private static GetPhotosOfAccommodations CreateQuery()
        {
            var dispatcher = new Mock<IProvider>();

            return new GetPhotosOfAccommodations(dispatcher.Object);
        }
    }
} 