using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    [TestFixture]
    internal class ByLanguageIdQueryTest
    {
        [Test]
        public void Instance_Is_QueryWithDependentProvider()
        {
            //Arrange
            var type = typeof(QueryWithDependentProvider<object>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        private static SomeByLanguageIdQuery Query()
        {
            var providerMock = new Mock<IProvider>();

            return new SomeByLanguageIdQuery(providerMock.Object);
        }

        [Test]
        public void LanguageId()
        {
            //Arrange
            var query = Query();

            //Act
            query.LanguageId = 1033;

            //Assert
            Assert.IsTrue(query.LanguageId == 1033);
        }
    }
}