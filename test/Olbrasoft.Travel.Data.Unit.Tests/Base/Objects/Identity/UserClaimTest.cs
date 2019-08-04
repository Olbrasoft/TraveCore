using NUnit.Framework;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Base.Objects.Identity;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Identity
{
    [TestFixture]
    internal class UserClaimTest
    {
        [Test]
        public void Instance_Implement_Interface_IHaveDateTimeOfCreation()
        {
            //Arrange
            var type = typeof(IHaveDateAndTimeOfCreation);

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