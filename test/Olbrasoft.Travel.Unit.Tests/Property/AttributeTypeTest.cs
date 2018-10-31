using NUnit.Framework;
using Olbrasoft.Travel.Property;
using System;

namespace Olbrasoft.Travel.Unit.Tests.Property
{
    [TestFixture]
    internal class AttributeTypeTest
    {
        [Test]
        public void First_AttributeType_Name_Is_Amenity()
        {
            //Arrange
            const string name = "Amenity";

            //Act
            var result = Enum.GetName(typeof(AttributeType), 1);

            //Assert
            Assert.IsTrue(name == result);
        }

        [Test]
        public void Two_AttributeType_Name_Is_Amenity()
        {
            //Arrange
            const string name = "Policy";

            //Act
            var result = Enum.GetName(typeof(AttributeType), 2);

            //Assert
            Assert.IsTrue(name == result);
        }
    }
}