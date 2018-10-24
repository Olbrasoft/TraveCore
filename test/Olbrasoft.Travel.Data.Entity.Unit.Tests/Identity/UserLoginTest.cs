using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Identity;

namespace Olbrasoft.Travel.Data.Entity.Unit.Tests.Identity
{
    [TestFixture]
    internal class UserLoginTest
    {
        [Test]
        public void Instance_Is_IdentityUserLogin_Of_Integer()
        {
            //Arrange
            var type = typeof(IdentityUserLogin<int>);

            //Act
            var userLogin = new UserLogin();

            //Assert
            Assert.IsInstanceOf(type, userLogin);
        }

        [Test]
        public void Instance_Implement_Interface_IHaveDateTimeOfCreation()
        {
            //Arrange
            var type = typeof(IHaveDateTimeOfCreation);

            //Act
            var userLogin = new UserLogin();

            //Assert
            Assert.IsInstanceOf(type, userLogin);
        }
    }
}