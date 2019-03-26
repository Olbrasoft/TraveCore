using NUnit.Framework;
using Olbrasoft.Travel.Data.Geography;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Unit.Tests.Geography
{
    [TestFixture]
    internal class SubtypeTest
    {
        [Test]
        public void Description()
        {
            //Arrange
            const string description = "Description of Subtype.";
            var regionType = new Subtype
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
            var type = new Subtype
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
            var type = typeof(ICanHaveSuggestionType);

            //Act
            var subtype = new Subtype();

            //Assert
            Assert.IsInstanceOf(type, subtype);
        }

        [Test]
        public void SuggestionTypeId()
        {
            //Arrange
            const int suggestionTypeId = 1976;

            //Act
            var subtype = new Subtype { SuggestionTypeId = suggestionTypeId };

            //Assert
            Assert.AreEqual(suggestionTypeId, subtype.SuggestionTypeId);
        }

        [Test]
        public void SuggestionType()
        {
            //Arrange
            var suggestionType = new SuggestionType();

            //Act
            var subtype = new Subtype { SuggestionType = suggestionType };

            //Assert
            Assert.AreSame(suggestionType, subtype.SuggestionType);
        }
    }
}