using Moq;
using NUnit.Framework;
using Olbrasoft.Pagination;

namespace Olbrasoft.Travel.Data.Unit.Tests
{
    [TestFixture]
    internal class LocalizedAccommodationPagedQueryTest
    {
        [Test]
        public void Is_Instance_Of_ILocalizedAccommodationPagedQuery()
        {
            //Arrange
            var type = typeof(ILocalizedAccommodationsPagedQuery);

            //Act
            var query = new LocalizedAccommodationsPagedQuery();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void LanguageId_Set_Get()
        {
            //Arrange
            ILocalizedAccommodationsPagedQuery query = new LocalizedAccommodationsPagedQuery { LanguageId = 8 };

            //Act
            var resultLanguageId = query.LanguageId;

            //Assert
            Assert.IsTrue(resultLanguageId == 8);
        }

        [Test]
        public void Paging_Set_Get()
        {
            //Arrange
            var pageInfoMock = new Mock<IPageInfo>();
            var pageInfo = pageInfoMock.Object;

            ILocalizedAccommodationsPagedQuery query = new LocalizedAccommodationsPagedQuery
            {
                Paging = pageInfo
            };

            //Act
            IPageInfo resultPageInfo = query.Paging;

            //Assert
            Assert.AreSame(resultPageInfo, pageInfo);
        }
    }
}