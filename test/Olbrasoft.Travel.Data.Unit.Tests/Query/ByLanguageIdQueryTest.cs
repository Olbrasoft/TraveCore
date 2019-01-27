using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Queries;
using Olbrasoft.Travel.Data.Query;

namespace Olbrasoft.Travel.Data.Unit.Tests.Query
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
            Assert.IsInstanceOf(type,query);
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
            Assert.IsTrue(query.LanguageId==1033);

        }

        
    }

    internal class SomeByLanguageIdQuery : ByLanguageIdQuery<object>
    {
        public SomeByLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}