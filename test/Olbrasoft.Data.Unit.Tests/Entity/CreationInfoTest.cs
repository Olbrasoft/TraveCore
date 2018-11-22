using NUnit.Framework;
using System;
using Olbrasoft.Travel.Data.Entity;

namespace Olbrasoft.Data.Unit.Tests.Entity
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
                DateAndTimeOfCreation = dateTime
            };

            //Act
            var dateAndTimeOfCreation = childCreationInfo.DateAndTimeOfCreation;

            //Assert
            Assert.IsTrue(dateAndTimeOfCreation == dateTime);
        }
    }

    internal class ChildCreationInfo : CreationInfo<int>
    {
    }
}