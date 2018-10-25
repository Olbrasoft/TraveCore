﻿using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests
{
    [TestFixture]
    internal class IdentityDatabaseContextTest
    {
        [Test]
        public void Instance_Is_DbContext()
        {
            //Arrange
            var type = typeof(DbContext);

            //Act
            var context = new IdentityDatabaseContext();

            //Assert
            Assert.IsInstanceOf(type, context);
        }

        [Test]
        public void Instance_Implement_Interface_IIdentityContext()
        {
            //Arrange
            var type = typeof(IIdentityContext);

            //Act
            var context = new IdentityDatabaseContext();

            //Assert
            Assert.IsInstanceOf(type, context);

        }
    }
}