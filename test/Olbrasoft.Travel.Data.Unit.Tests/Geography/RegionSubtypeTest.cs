using NUnit.Framework;
using Olbrasoft.Travel.Data.Geography;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Suggestion;

namespace Olbrasoft.Travel.Data.Unit.Tests.Geography
{
    [TestFixture]
    internal class RegionSubtypeTest
    {
        [Test]
        public void Description()
        {
            //Arrange
            const string description = "Description of RegionSubtype.";
            var regionType = new RegionSubtype
            {
                Description = description
            };

            //Act
            var result = regionType.Description;

            //Assert
            Assert.IsTrue(result == description);
        }

        [Test]
        public void Regions()
        {
            //Arrange
            ICollection<Region> regions = new[] { new Region() };
            var type = new RegionSubtype
            {
                Regions = regions
            };

            //Act
            var result = type.Regions;

            //Assert
            Assert.AreSame(regions, result);
        }

        [Test]
        public void Instance_Implement_Interface_ICanHaveSuggestionType()
        {
            //Arrange
            var type = typeof(IHaveSuggestionCategory);

            //Act
            var subtype = new RegionSubtype();

            //Assert
            Assert.IsInstanceOf(type, subtype);
        }

        [Test]
        public void SuggestionTypeId()
        {
            //Arrange
            const int suggestionTypeId = 1976;

            //Act
            var subtype = new RegionSubtype { SuggestionCategoryId = suggestionTypeId };

            //Assert
            Assert.AreEqual(suggestionTypeId, subtype.SuggestionCategoryId);
        }

        [Test]
        public void SuggestionType()
        {
            //Arrange
            var suggestionType = new SuggestionCategory();

            //Act
            var subtype = new RegionSubtype { SuggestionCategory = suggestionType };

            //Assert
            Assert.AreSame(suggestionType, subtype.SuggestionCategory);
        }
    }
}