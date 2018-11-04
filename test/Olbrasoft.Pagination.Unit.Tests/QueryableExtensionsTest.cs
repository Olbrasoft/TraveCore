using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Olbrasoft.Collections.Generic;


namespace Olbrasoft.Pagination.Unit.Tests
{
    [TestFixture]
    internal class QueryableExtensionsTest
    {
        [Test]
        public void Is_Instance_Of_PagedList()
        {
            //Arrange
            var source = new List<object>().AsQueryable();
            var pagingMock = new Mock<IPageInfo>();
            pagingMock.Setup(p => p.NumberOfSelectedPage).Returns(1);

            //Act
            var result = source.AsPagedList(pagingMock.Object);

            //Assert
            Assert.IsInstanceOf<PagedList<object>>(result);
        }

        [Test]
        public void Source_Throw_ArgumentNullException()
        {
            //Arrange
            IQueryable<object> source = null;
            var pagingMock = new Mock<IPageInfo>();
            ArgumentException exception = null;

            //Act
            try
            {
                // ReSharper disable once ExpressionIsAlwaysNull
                source.AsPagedList(pagingMock.Object);
            }
            catch (ArgumentException e)
            {
                exception = e;
            }

            //Assert
            // ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual("source", exception.ParamName);
        }

        [Test]
        public void Paging_Throw_ArgumentNullException()
        {
            //Arrange
            var source = new List<object>().AsQueryable();
            ArgumentException exception = null;

            //Act
            try
            {
                // ReSharper disable once ExpressionIsAlwaysNull
                source.AsPagedList(null);
            }
            catch (ArgumentException e)
            {
                exception = e;
            }

            //Assert
            // ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual("paging", exception.ParamName);
        }
    }
}