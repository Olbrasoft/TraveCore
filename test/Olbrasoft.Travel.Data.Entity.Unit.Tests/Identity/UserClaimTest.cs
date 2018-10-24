using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Identity;

namespace Olbrasoft.Travel.Data.Entity.Unit.Tests.Identity
{
    [TestFixture]
    internal class UserClaimTest
    {
        [Test]
        public void Instance_Implement_Interface_IHaveDateTimeOfCreation()
        {
            //Arrange
            var type = typeof(IHaveDateTimeOfCreation);

            //Act
            var userClaim = new UserClaim();

            //Assert
            Assert.IsInstanceOf(type, userClaim);
        }

        [Test]
        public void Instance_Is_IdentityUserClaim_Of_Integer()
        {
            //Arrange
            var type = typeof(Microsoft.AspNetCore.Identity.IdentityUserClaim<int>);

            //Act
            var userClaim = new UserClaim();

            //Assert
            Assert.IsInstanceOf(type,userClaim);
        }
    }
}