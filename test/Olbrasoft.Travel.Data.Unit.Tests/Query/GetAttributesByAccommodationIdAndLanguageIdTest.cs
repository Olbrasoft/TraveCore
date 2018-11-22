using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Query;
using Olbrasoft.Globalization;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Query;

namespace Olbrasoft.Travel.Data.Unit.Tests.Query
{
    internal class GetAttributesByAccommodationIdAndLanguageIdTest
    {
        [Test]
        public void Instance_Implement_Interface_IQuery_Of_IEnumerable_Of_Attributes()
        {
            //Arrange
            var type = typeof(IQuery<IEnumerable<Data.Transfer.Object.Attribute>>);
            var providerMock = new Mock<IProvider>();

            //Act
            var query = new GetAttributesByAccommodationIdAndLanguageId(providerMock.Object);
            
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
            var query = new GetAttributesByAccommodationIdAndLanguageId(providerMock.Object);

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Implement_Interface_IHaveLanguageId_Of_Integer()
        {
            //Arrange
            var type = typeof(IHaveLanguageId<int>);
            var providerMock = new Mock<IProvider>();

            //Act
            var query = new GetAttributesByAccommodationIdAndLanguageId(providerMock.Object);

            //Assert
            Assert.IsInstanceOf(type, query);
        }
    }
}