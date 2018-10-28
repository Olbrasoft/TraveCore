using System;
using System.Linq;
using NUnit.Framework;
using Olbrasoft.Extensions;
using Olbrasoft.Travel.Geography;

namespace Olbrasoft.Travel.Unit.Tests.Geography
{
    [TestFixture]
    internal class RegionTypeTest
    {
        [Test]
        public void RegionType_Number_Is_Greater_Than_Eleven()
        {
            //Arrange
            const int minNumber = 11;

            //Act
            var number = Enum.GetNames(typeof(RegionType)).Length;

            //Assert
            Assert.IsTrue(number > minNumber);
        }

        [Test]
        public void Top_RegionType_Name_Is_World()
        {
            //Arrange
            const string world = "World";

            //Act
            var result = Enum.GetNames(typeof(RegionType)).First();

            //Assert
            Assert.IsTrue(world == result);
        }

        [Test]
        public void Enum_GetName_Type_Of_RegionType_Six_Return_MultiCity()
        {
            //Arrange
            const string name = "MultiCity";

            //Act
            var result = Enum.GetName(typeof(RegionType), 6);

            //Assert
            Assert.IsTrue(name == result);
        }

        [Test]
        public void Get_Value_Of_DescriptionAttribute()
        {
            //Arrange
            const string description = "Multi-Region (within a country)";

            //Act
            var result = RegionType.MultiRegion.GetDescription();

            //Assert
            Assert.IsTrue(description == result);
        }

        [Test]
        public void GetValue()
        {
            //Arrange
            const RegionType pointOfInterest = RegionType.PointOfInterest;
            const string description = "Point of Interest";

            //Act
            var result = Enum.Parse<RegionType>("PointOfInterest");

            //Assert

            Assert.Multiple(() =>
            {
                Assert.IsTrue(result == pointOfInterest);
                Assert.IsTrue(description == result.GetDescription());
            });
        }
    }
}