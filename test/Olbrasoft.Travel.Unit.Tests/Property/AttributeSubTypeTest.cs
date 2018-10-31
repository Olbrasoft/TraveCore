using NUnit.Framework;
using System;
using Olbrasoft.Travel.Property;

namespace Olbrasoft.Travel.Unit.Tests.Property
{
    [TestFixture]
    internal class AttributeSubTypeTest
    {
        [Test]
        public void AttributeSubType_Name_Of_Value_One_Is_AmenityOfAccommodation()
        {
            //Arrange
            const string name = "AmenityOfAccommodation";

            //Act
            var result = Enum.GetName(typeof(AttributeSubType), 1);

            //Assert
            Assert.IsTrue(name == result);
        }

        [Test]
        public void AttributeSubType_Name_Of_Value_Two_Is_AmenityOfRoom()
        {
            //Arrange
            const string name = "AmenityOfRoom";

            //Act
            var result = Enum.GetName(typeof(AttributeSubType), 2);

            //Assert
            Assert.IsTrue(name == result);
        }

        [Test]
        public void AttributeSubType_Name_Of_Value_Three_Is_CheckInOut()
        {
            //Arrange
            const string name = "CheckInOut";

            //Act
            var result = Enum.GetName(typeof(AttributeSubType), 3);

            //Assert
            Assert.IsTrue(name == result);
        }

        [Test]
        public void AttributeSubType_Name_Of_Value_Four_Is_Other()
        {
            //Arrange
            const string name = "Other";

            //Act
            var result = Enum.GetName(typeof(AttributeSubType), 4);

            //Assert
            Assert.IsTrue(name == result);
        }

        [Test]
        public void AttributeSubType_Name_Of_Value_Five_Is_Payment()
        {
            //Arrange
            const string name = "Payment";

            //Act
            var result = Enum.GetName(typeof(AttributeSubType), 5);

            //Assert
            Assert.IsTrue(name == result);
        }

        [Test]
        public void AttributeSubType_Name_Of_Value_Six_Is_Pets()
        {
            //Arrange
            const string name = "Pets";

            //Act
            var result = Enum.GetName(typeof(AttributeSubType), 6);

            //Assert
            Assert.IsTrue(name == result);
        }
    }
}