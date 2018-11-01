using System;
using NUnit.Framework;

namespace Olbrasoft.Pagination.Unit.Tests
{
    [TestFixture]
    internal class PageInfoExtensionsTest
    {
        [Test]
        public void PageInfo_Throw_ArgumentNullException()
        {
            //Arrange
            IPageInfo pageInfo = null;
            ArgumentException exception = null;

            //Act
            try
            {
                // ReSharper disable once ExpressionIsAlwaysNull
                pageInfo.CalculateSkip();
            }
            catch (ArgumentException e)
            {
                exception = e;
            }

            //Assert
            Assert.Multiple(() =>
            {
               Assert.IsInstanceOf<ArgumentNullException>(exception);
               // ReSharper disable once PossibleNullReferenceException
               Assert.AreEqual("pageInfo", exception.ParamName);
            });
        }

        [Test]
        public void CalculateSkip_Return_Twenty()
        {
            //Arrange
            var pageInfo = new PageInfo(10,3);

            //Act
            var skip = pageInfo.CalculateSkip();

            //Assert
            Assert.IsTrue(skip==20);
        }
    }
}