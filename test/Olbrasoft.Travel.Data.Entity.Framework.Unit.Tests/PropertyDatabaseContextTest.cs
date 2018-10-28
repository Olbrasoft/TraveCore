using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests
{
    [TestFixture]
    internal class PropertyDatabaseContextTest
    {
        [Test]
        public void Instance_Is_DbContext()
        {
            //Arrange
            var type = typeof(DbContext);
            //Act
            var context = PropertyContext();

            //Assert
            Assert.IsInstanceOf(type, context);
        }

        [Test]
        public void Instance_Implement_Interface_IProperty()
        {
            //Arrange
            var type = typeof(IPropertyContext);

            //Act
            var context = PropertyContext();

            //Assert
            Assert.IsInstanceOf(type, context);
        }

        private static PropertyDatabaseContext PropertyContext()
        {
            return new PropertyDatabaseContext();
        }
    }
}