using System;
using System.Linq;
using NUnit.Framework;
using Olbrasoft.Extensions;
using Olbrasoft.Travel.Suggestion;

namespace Olbrasoft.Travel.Unit.Tests.Suggestion
{
    public class CategoriesOfSuggestionTest
    {
        [Test]
        public void Count_Is_Greater_Than_Three()
        {
            //Arrange
            const int minNumber = 3;

            //Act
            var number = Enum.GetNames(typeof(SuggestionCategories)).Length;

            //Assert
            Assert.IsTrue(number > minNumber);
        }

        [Test]
        public void Top_Group_Name_Is_AreasCities()
        {
            //Arrange
            const string areasCities = "AreasCities";

            //Act
            var result = Enum.GetNames(typeof(SuggestionCategories)).First();

            //Assert
            Assert.IsTrue(areasCities == result);
        }

        [Test]
        public void AreasCities_GetDescriptions_Return_Cities_Slash_Areas()
        {
            //Arrange
            const string description = "Cities/Areas";

            //Act
            var result = SuggestionCategories.AreasCities.GetDescription();

            //Assert
            Assert.IsTrue(description == result);
        }

        [Test]
        public void Enum_GetName_Type_Of_CategoriesOfSuggestion_Two_Return_Properties()
        {
            //Arrange
            const string name = "Properties";

            //Act
            var result = Enum.GetName(typeof(SuggestionCategories), 2);

            //Assert
            Assert.IsTrue(name == result);
        }

        [Test]
        public void Properties_GetDescriptions_Return_Properties()
        {
            //Arrange
            const string description = "Properties";

            //Act
            var result = SuggestionCategories.Properties.GetDescription();

            //Assert
            Assert.IsTrue(description == result);
        }

        [Test]
        public void Enum_GetName_Type_Of_CategoriesOfSuggestion_Three_Return_Landmarks()
        {
            //Arrange
            const string name = "Landmarks";

            //Act
            var result = Enum.GetName(typeof(SuggestionCategories), 3);

            //Assert
            Assert.IsTrue(name == result);
        }

        [Test]
        public void Landmarks_GetDescriptions_Return_Landmarks()
        {
            //Arrange
            const string description = "Landmarks";

            //Act
            var result = SuggestionCategories.Landmarks.GetDescription();

            //Assert
            Assert.IsTrue(description == result);
        }

        [Test]
        public void Enum_GetName_Type_Of_CategoriesOfSuggestion_Four_Return_AirportsStations()
        {
            //Arrange
            const string name = "AirportsStations";

            //Act
            var result = Enum.GetName(typeof(SuggestionCategories), 4);

            //Assert
            Assert.IsTrue(name == result);
        }

        [Test]
        public void Landmarks_GetDescriptions_Return_Airports_Slash_Stations()
        {
            //Arrange
            const string description = "Airports/Stations";

            //Act
            var result = SuggestionCategories.AirportsStations.GetDescription();

            //Assert
            Assert.IsTrue(description == result);
        }
    }
}