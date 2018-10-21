using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Olbrasoft.TravelCore.Data.Entity.Identity;

namespace Olbrasoft.TravelCore.Data.Entity.Unit.Tests.Identity
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
            var type = typeof(IHaveDateTimeOfCreation);

            //Act
            var userToken= new UserToken();

            //Assert
            Assert.IsInstanceOf(type,userToken);
        }

    }
}