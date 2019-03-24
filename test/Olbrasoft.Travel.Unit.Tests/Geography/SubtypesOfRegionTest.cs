using Olbrasoft.Extensions;
using Olbrasoft.Travel.Geography;
using System;
using System.Linq;
using NUnit.Framework;

namespace Olbrasoft.Travel.Unit.Tests.Geography
{
    internal class SubtypesOfRegionTest
    {
        [Test]
        public void RegionType_Number_Is_Greater_Than_Eleven()
        {
            //Arrange
            const int minNumber = 11;

            //Act
            var number = Enum.GetNames(typeof(SubtypesOfRegion)).Length;

            //Assert
            Assert.IsTrue(number > minNumber);
        }

        [Test]
        public void Top_RegionType_Name_Is_World()
        {
            //Arrange
            const string world = "World";

            //Act
            var result = Enum.GetNames(typeof(SubtypesOfRegion)).First();

            //Assert
            Assert.IsTrue(world == result);
        }

        [Test]
        public void Enum_GetName_Type_Of_RegionType_Six_Return_MultiCity()
        {
            //Arrange
            const string name = "MultiCity";

            //Act
            var result = Enum.GetName(typeof(SubtypesOfRegion), 6);

            //Assert
            Assert.IsTrue(name == result);
        }

        [Test]
        public void Get_Value_Of_DescriptionAttribute()
        {
            //Arrange
            const string description = "Multi-Region (within a country)";

            //Act
            var result = SubtypesOfRegion.MultiRegion.GetDescription();

            //Assert
            Assert.IsTrue(description == result);
        }

        [Test]
        public void GetValue()
        {
            //Arrange
            const SubtypesOfRegion pointOfInterest = SubtypesOfRegion.PointOfInterest;
            const string description = "Point of Interest";

            //Act
            var result = Enum.Parse<SubtypesOfRegion>("PointOfInterest");

            //Assert

            Assert.Multiple(() =>
            {
                Assert.IsTrue(result == pointOfInterest);
                Assert.IsTrue(description == result.GetDescription());
            });
        }
    }
}