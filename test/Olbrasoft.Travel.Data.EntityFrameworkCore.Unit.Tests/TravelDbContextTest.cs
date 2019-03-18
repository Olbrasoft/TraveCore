using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Identity;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests
{
    [TestFixture]
    public class TravelDbContextTest
    {
        [Test]
        public void Instance_Is_DbContext()
        {
            //Arrange
            var type = typeof(DbContext);

            //Act
            var context = TravelContext();

            //Assert
            Assert.IsInstanceOf(type, context);
        }

        [Test]
        public void Instance_Is_IdentityDbContext_Of_User_Comma_Role_Comma_Integer_Comma_UserClaim_Comma_UserRole_Comma_UserLogin_Comma_RoleClaim_Comma_UserToken()
        {
            //Arrange
            var type = typeof(Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>);

            //Act
            var dbc = TravelContext();

            //Assert
            Assert.IsInstanceOf(type, dbc);
        }

        private static TravelDbContext TravelContext()
        {
            var context = new TravelDbContext();
            return context;
        }


        [Test]
        public void Users_Set()
        {
            //Arrange
            var context = TravelContext();
            var users = new Mock<DbSet<User>>().Object;

            //Act
            context.Users = users;

            //Assert
            Assert.AreSame(users, context.Users);
        }

        //[Test]
        //public void Users_Set_Get()
        //{
        //    //Arrange
        //    var users = new Mock<DbSet<User>>().Object;
        //    var context = TravelContext();
        //    context.Users = users;

        //    //Act
        //    var result = context.Users;

        //    //Assert
        //    Assert.IsInstanceOf<DbSet<User>>(result);
        //}
    }
}