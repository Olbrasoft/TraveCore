using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Base.Objects.Geography;
using Olbrasoft.Travel.Data.Base.Objects.Identity;
using System;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Identity
{
    [TestFixture]
    internal class UserTest
    {
        [Test]
        public void Instance_Implement_Interface_IHaveDateTimeOfCreation()
        {
            //Arrange
            var type = typeof(IHaveDateAndTimeOfCreation);

            //Act
            var user = User();

            //Assert
            Assert.IsInstanceOf(type, user);
        }

        private static User User()
        {
            var user = new User();
            return user;
        }

        [Test]
        public void Instance_Is_IdentityUser_Of_Integer()
        {
            //Arrange
            var type = typeof(IdentityUser<int>);

            //Act
            var user = new User();

            //Assert
            Assert.IsInstanceOf(type, user);
        }

        [Test]
        public void Created()
        {
            //Arrange
            var dateAndTime = DateTime.Now;
            var user = new User { Created = dateAndTime };

            //Act
            var result = user.Created;

            //Assert
            Assert.AreEqual(dateAndTime, result);
        }

        [Test]
        public void RegionSubtypes()
        {
            //Arrange
            var regionSubtypes = new[] { new RegionSubtype() };
            var user = new User
            {
                RegionSubtypes = regionSubtypes
            };

            //Act
            var result = user.RegionSubtypes;

            //Assert
            Assert.AreSame(regionSubtypes, result);
        }

        [Test]
        public void RegionsToSubclasses()
        {
            //Arrange
            ICollection<RegionToSubclass> regionsToSubclasses = new[] { new RegionToSubclass() };
            var user = new User { RegionsToSubclasses = regionsToSubclasses };

            //Act
            var result = user.RegionsToSubclasses;

            //Assert
            Assert.AreSame(regionsToSubclasses, result);
        }

        [Test]
        public void RegionsToProperties()
        {
            //Arrange
            ICollection<PropertyToRegion> regionToProperties = new List<PropertyToRegion>();
            var user = Create();

            //Act
            user.PropertiesToRegions = regionToProperties;

            //Assert
            Assert.AreSame(regionToProperties, user.PropertiesToRegions);
        }

        private static User Create()
        {
            var user = new User();
            return user;
        }
    }
}