using NUnit.Framework;

namespace Olbrasoft.Pagination.Unit.Tests
{
    [TestFixture]
    public class PageInfoTest
    {
        public PageInfo PageInfo { get; set; }

        [SetUp]
        public void Setup()
        {
            PageInfo = new PageInfo();
        }

        [Test]
        public void CreateInstanceOfTypePageUnitTestMethod()
        {
            //Arrange
            var pageInfo = PageInfo;

            //Act
            var typePagination = typeof(PageInfo);

            //Assert
            Assert.IsInstanceOf(typePagination, pageInfo);

        }

        [Test]
        public void PageSizeTypeUnitTestMethod()
        {
            //Arrange 
            var pageInfo = new PageInfo();

            //Act
            var pageSize = pageInfo.PageSize;

            //Assert
            Assert.IsInstanceOf<int>(pageSize);
        }


        [Test]
        public void PageNumberUnitTest()
        {
            //Arrange
            var pageInfo = new PageInfo();

            //Act
            var pageNumber = pageInfo.NumberOfSelectedPage;

            //Assert
            Assert.IsInstanceOf<int>(pageNumber);
        }

        [Test]
        public void PageSizeDefaultValueUnitTestMethod()
        {
            //Arrange
            var pageInfo = PageInfo;

            //Act
            var pageSize = pageInfo.PageSize;

            //Assert 
            Assert.IsTrue(pageSize > 0);

        }

        [Test]
        public void PageNumberDefaultValueUnitTestMethod()
        {
            //Arrange 
            var pageInfo = PageInfo;

            //Act
            var pageNumber = pageInfo.NumberOfSelectedPage;

            //Assert
            Assert.IsTrue(pageNumber == 1);
        }

    }
}
