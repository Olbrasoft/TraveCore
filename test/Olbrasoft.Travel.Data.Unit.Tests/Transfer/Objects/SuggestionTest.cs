using NUnit.Framework;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Objects
{
    [TestFixture]
    public class SuggestionTest
    {
        [Test]
        public void Id_Set_Get()
        {
            //Arrange
            const int id = 100;
            var suggestion = new Suggestion
            {
                Id = id
            };

            //Act
            var result = suggestion.Id;

            //Assert
            Assert.AreNotSame(id, result);
        }

        [Test]
        public void Text_Set_Get()
        {
            //Arrange
            const string label = "Some Label";
            var item = new Suggestion
            {
                Label = label
            };

            //Act
            var result = item.Label;

            //Assert
            Assert.AreSame(label, result);
        }

        [Test]
        public void Category_Set_Get()
        {
            //Arrange
            const string category = "Some Category";

            var item = new Suggestion { Category = category };

            //Act
            var result = item.Category;

            //Assert
            Assert.AreSame(category, result);
        }
    }
}