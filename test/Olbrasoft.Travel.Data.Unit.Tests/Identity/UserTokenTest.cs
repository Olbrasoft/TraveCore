using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Identity;

namespace Olbrasoft.Travel.Data.Unit.Tests.Identity
{
    [TestFixture]
    internal class UserTokenTest
    {
        [Test]
        public void Instance_Is_IdentityUserToken_Of_Integer()
        {
            //Arrange
            var type = typeof(IdentityUserToken<int>);

            //Act
            var userToken = new UserToken();

            //Assert
            Assert.IsInstanceOf(type,userToken);
        }


        [Test]
        public void Instance_Implement_Interface_IHaveDateAndTimeOfCreation()
        {
            //Arrange
            var type = typeof(IHaveDateAndTimeOfCreation);

            //Act
            var userToken= new UserToken();

            //Assert
            Assert.IsInstanceOf(type,userToken);
        }

    }
}