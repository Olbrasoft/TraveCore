using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Queries;
using Olbrasoft.Globalization;
using Olbrasoft.Travel.Data.Queries;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    internal class AttributesByAccommodationIdAndLanguageIdQueryTest
    {

        [Test]
        public void Instance_Is_ByAccommodationIdAndLanguageIdQuery_Of_IEnumerable_Of_Attribute()
        {
            //Arrange
            var type = typeof(ByAccommodationIdAndLanguageIdQuery<IEnumerable<Data.Transfer.Object.Attribute>>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);

        }

        [Test]
        public void Instance_is_ByLanguageIdQuery_Of_IEnumerable_Of_Attribute()
        {
            //Arrange
            var type = typeof(ByLanguageIdQuery<IEnumerable<Data.Transfer.Object.Attribute>>);
            
            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);

        }

        private static AttributesByAccommodationIdAndLanguageIdQuery Query()
        {
            var providerMock = new Mock<IProvider>();

            //Act
            var query = new AttributesByAccommodationIdAndLanguageIdQuery(providerMock.Object);
            return query;
        }


        [Test]
        public void Instance_Implement_Interface_IQuery_Of_IEnumerable_Of_Attributes()
        {
            //Arrange
            var type = typeof(IQuery<IEnumerable<Data.Transfer.Object.Attribute>>);
            var providerMock = new Mock<IProvider>();

            //Act
            var query = new AttributesByAccommodationIdAndLanguageIdQuery(providerMock.Object);
            
            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Implement_Interface_IHaveAccommodationId()
        {
            //Arrange
            var type = typeof(IHaveAccommodationId);
            var providerMock = new Mock<IProvider>();

            //Act
            var query = new AttributesByAccommodationIdAndLanguageIdQuery(providerMock.Object);

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void AccommodationId_Get_Set()
        {
            //Arrange
            const int accommodationId = int.MaxValue;
            var providerMock = new Mock<IProvider>();

            var query = new AttributesByAccommodationIdAndLanguageIdQuery(providerMock.Object)
            {
                AccommodationId = accommodationId
            };

            //Act
            var result = query.AccommodationId;


            //Assert
            Assert.IsTrue(result==accommodationId);
        }

        
        [Test]
        public void Instance_Implement_Interface_IHaveLanguageId_Of_Integer()
        {
            //Arrange
            var type = typeof(IHaveLanguageId<int>);
            var providerMock = new Mock<IProvider>();

            //Act
            var query = new AttributesByAccommodationIdAndLanguageIdQuery(providerMock.Object);

            //Assert
            Assert.IsInstanceOf(type, query);
        }

    }
}