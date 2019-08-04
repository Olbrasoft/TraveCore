using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Base.Objects.Identity;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Identity
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
            var type = typeof(IHaveDateAndTimeOfCreation);

            //Act
            var userLogin = new UserLogin();

            //Assert
            Assert.IsInstanceOf(type, userLogin);
        }
    }
}