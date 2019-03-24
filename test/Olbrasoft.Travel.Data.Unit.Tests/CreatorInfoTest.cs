using System;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Unit.Tests
{
    [TestFixture]
    internal class CreatorInfoTest
    {
        [Test]
        public void Instance_Implement_Interface_ICreation()
        {
            //Arrange
            var type = typeof(IHaveId<int>);

            //Act
            var creator = new CreatorInfo<int, int>();

            //Assert
            Assert.IsInstanceOf(type, creator);
        }

        [Test]
        public void CreatorId()
        {
            //Arrange
            var guid = new Guid();
            var creatorInfo = new CreatorInfo<int, Guid>()
            {
                CreatorId = guid
            };

            //Act
            var result = creatorInfo.CreatorId;

            //Assert
            Assert.IsTrue(result == guid);
        }

        [Test]
        public void Creator()
        {
            //Arrange
            var user = new User<Guid>();
            var creatorInfo = new CreatorInfo<int, Guid>()
            {
                Creator = user
            };

            //Act
            var result = creatorInfo.Creator;

            //Assert

            Assert.AreSame(result, user);
        }
    }
}