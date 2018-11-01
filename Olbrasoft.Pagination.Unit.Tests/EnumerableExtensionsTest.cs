using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Olbrasoft.Collections.Generic;
using X.PagedList;


namespace Olbrasoft.Pagination.Unit.Tests
{
    [TestFixture]
    internal class EnumerableExtensionsTest
    {
        [Test]
        public void ToPagedList_Return_Is_Instance_Of_PagedList()
        {
            //Arrange
            IEnumerable<object> source = new List<object>();
            var type = typeof(Collections.Generic.PagedList<object>);

            //Act
            var result = source.ToPagedList();

            //Assert
            Assert.IsInstanceOf(type, result);



        }


        [Test]
        public void Source_ArgumentNullException()
        {
            //Arrange
            IEnumerable<object> source = null;
            ArgumentNullException exception = null;

            //Act
            try
            {
                // ReSharper disable once ExpressionIsAlwaysNull
                source.ToPagedList();
        
            }
            catch (ArgumentNullException ex)
            {
                exception = ex;
                
            }

            //Assert
            // ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual("source", exception.ParamName);
        }


        [Test]
        public void Pagination_ArgumentNullException()
        {
            //Arrange
            IEnumerable<object> source = new List<object>();
            ArgumentNullException exception = null;

            //Act
            try
            {
                source.ToPagedList(null);
            }
            catch (ArgumentNullException e)
            {
                exception = e;
            }

            //Assert
            // ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual("pagination", exception.ParamName);
        }


        [Test]
        public void ToPagedList_with_pagination_when_source_is_null()
        {
            //Arrange
            IEnumerable<object> source = null;
            var paginationMock = new Mock<IPagination>();
            ArgumentNullException exception = null;

            //Act
            try
            {
                // ReSharper disable once ExpressionIsAlwaysNull
                source.ToPagedList(paginationMock.Object);
            }
            catch (ArgumentNullException e)
            {
                exception = e;
            }


            //Assert
            
            // ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual("source", exception.ParamName);
        }
    }


}