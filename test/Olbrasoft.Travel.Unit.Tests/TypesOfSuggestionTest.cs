using NUnit.Framework;
using Olbrasoft.Extensions;
using System;
using System.Linq;

namespace Olbrasoft.Travel.Unit.Tests
{
    public class TypesOfSuggestionTest
    {
        [Test]
        public void Count_Is_Greater_Than_Three()
        {
            //Arrange
            const int minNumber = 3;

            //Act
            var number = Enum.GetNames(typeof(TypesOfSuggestion)).Length;

            //Assert
            Assert.IsTrue(number > minNumber);
        }

        [Test]
        public void Top_Group_Name_Is_AreasCities()
        {
            //Arrange
            const string areasCities = "AreasCities";

            //Act
            var result = Enum.GetNames(typeof(TypesOfSuggestion)).First();

            //Assert
            Assert.IsTrue(areasCities == result);
        }

        [Test]
        public void AreasCities_GetDescriptions_Return_Cities_Slash_Areas()
        {
            //Arrange
            const string description = "Cities/Areas";

            //Act
            var result = TypesOfSuggestion.AreasCities.GetDescription();

            //Assert
            Assert.IsTrue(description == result);
        }

        [Test]
        public void Enum_GetName_Type_Of_TypesOfSuggestion_One_Return_RealEstates()
        {
            //Arrange
            const string name = "RealEstates";

            //Act
            var result = Enum.GetName(typeof(TypesOfSuggestion), 1);

            //Assert
            Assert.IsTrue(name == result);
        }

        [Test]
        public void RealEstates_GetDescriptions_Return_Properties()
        {
            //Arrange
            const string description = "Properties";

            //Act
            var result = TypesOfSuggestion.RealEstates.GetDescription();

            //Assert
            Assert.IsTrue(description == result);
        }

        [Test]
        public void Enum_GetName_Type_Of_TypesOfSuggestion_Two_Return_Landmarks()
        {
            //Arrange
            const string name = "Landmarks";

            //Act
            var result = Enum.GetName(typeof(TypesOfSuggestion), 2);

            //Assert
            Assert.IsTrue(name == result);
        }

        [Test]
        public void Landmarks_GetDescriptions_Return_Landmarks()
        {
            //Arrange
            const string description = "Landmarks";

            //Act
            var result = TypesOfSuggestion.Landmarks.GetDescription();

            //Assert
            Assert.IsTrue(description == result);
        }

        [Test]
        public void Enum_GetName_Type_Of_TypesOfSuggestion_Three_Return_AirportsStations()
        {
            //Arrange
            const string name = "AirportsStations";

            //Act
            var result = Enum.GetName(typeof(TypesOfSuggestion), 3);

            //Assert
            Assert.IsTrue(name == result);
        }

        [Test]
        public void Landmarks_GetDescriptions_Return_Airports_Slash_Stations()
        {
            //Arrange
            const string description = "Airports/Stations";

            //Act
            var result = TypesOfSuggestion.AirportsStations.GetDescription();

            //Assert
            Assert.IsTrue(description == result);
        }
    }
}