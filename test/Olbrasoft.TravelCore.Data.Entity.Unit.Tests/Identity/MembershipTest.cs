using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Olbrasoft.TravelCore.Data.Entity.Identity;

namespace Olbrasoft.TravelCore.Data.Entity.Unit.Tests.Identity
{
    [TestFixture]
    internal class MembershipTest
    {
        [Test]
        public void Instance_Is_IdentityUserRole_Of_Integer()
        {
            //Arrange
            var type = typeof(IdentityUserRole<int>);

            //Act
            var membership= new Membership();

            //Assert
            Assert.IsInstanceOf(type,membership);
        }


        [Test]
        public void Instance_Implement_Interface_IHaveDateAndTimeOfCreation()
        {
            //Arrange
            var type = typeof(IHaveDateTimeOfCreation);

            //Act
            var membership= new Membership();

            //Assert
            Assert.IsInstanceOf(type,membership);
        }
    }
}