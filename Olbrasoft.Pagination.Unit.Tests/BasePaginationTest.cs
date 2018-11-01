using Moq;
using NUnit.Framework;

namespace Olbrasoft.Pagination.Unit.Tests
{
    [TestFixture]
    internal class BasePaginationTest
    {
        public IPageInfo PageInfo { get; set; }

        [SetUp]
        public void Setup()
        {
            PageInfo = GetPageInfo();
        }


        [Test]
        public void Is_Instance_Of_IPaging()
        {
            //Arrange
            var type = typeof(IPagination);
            

            //Act
            var somePagination = new SomePagination(PageInfo);

            //Assert
            Assert.IsInstanceOf(type, somePagination);
        }


        [Test]
        public void Is_Instance_Of_BasePagination()
        {
            //Arrange
            var type = typeof(BasePagination);
            
            //Act
            var somePagination = new SomePagination(PageInfo);

            //Assert
            Assert.IsInstanceOf(type, somePagination);
        }


        [Test]
        public void PageInfo_Size_Is_1000()
        {
            //Arrange
            var somePagination = new SomePagination(new PageInfo(1000));

            //Act
            var pageSize = somePagination.PageInfo.PageSize;

            //Assert
            Assert.IsTrue(pageSize==1000);

        }
        

        private static IPageInfo GetPageInfo()
        {
            var pageInfo = new Mock<IPageInfo>();
            pageInfo.Setup(p => p.NumberOfSelectedPage).Returns(3);
            pageInfo.Setup(p => p.PageSize).Returns(100);
            return pageInfo.Object;
        }


    }
}