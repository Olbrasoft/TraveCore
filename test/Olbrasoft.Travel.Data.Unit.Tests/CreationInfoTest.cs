using System;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Unit.Tests
{
    [TestFixture]
    internal class CreationInfoTest
    {
        [Test]
        public void Instance_Implement_Interface_ICreation()
        {
            //Arrange
            var type = typeof(IHaveId<int>);

            //Act
            var childCreationInfo = new ChildCreationInfo();

            //Assert
            Assert.IsInstanceOf(type, childCreationInfo);
        }

        [Test]
        public void Id()
        {
            //Arrange
            var childCreationInfo = new ChildCreationInfo()
            {
                Id = 10
            };

            //Act
            var id = childCreationInfo.Id;

            //Assert
            Assert.IsTrue(id == 10);
        }

        [Test]
        public void DateAndTimeOfCreation()
        {
            //Arrange
            var dateTime = DateTime.Now;
            var childCreationInfo = new ChildCreationInfo()
            {
                Created = dateTime
            };

            //Act
            var dateAndTimeOfCreation = childCreationInfo.Created;

            //Assert
            Assert.IsTrue(dateAndTimeOfCreation == dateTime);
        }
    }

    internal class ChildCreationInfo : CreationInfo<int>
    {
    }
}