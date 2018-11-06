using NUnit.Framework;

namespace Olbrasoft.Travel.Data.Unit.Tests
{
    [TestFixture]
    internal class LocalizedAccommodationByIdQueryTest
    {
        [Test]
        public void Is_Instance_Of_ILocalizedAccommodationByIdQuery()
        {
            //Arrange
            var type = typeof(ILocalizedAccommodationByIdQuery);

            //Act
            var query = new LocalizedAccommodationByIdQuery();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void MyTestMethod()
        {
            //Arrange
            ILocalizedAccommodationByIdQuery query = new LocalizedAccommodationByIdQuery { LanguageId = 13, Id = 56 };

            //Act
            var resultLanguageId = query.LanguageId;
            var resultId = query.Id;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(resultLanguageId == 13);

                Assert.IsTrue(resultId == 56);
            });
        }
    }
}