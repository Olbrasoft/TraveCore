using NUnit.Framework;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Objects
{
    [TestFixture]
    public class SuggestionDtoTest
    {
        [Test]
        public void Id_Set_Get()
        {
            //Arrange
            const int id = 100;
            var suggestion = new Data.Transfer.Objects.SuggestionDto
            {
                Id = id
            };

            //Act
            var result = suggestion.Id;

            //Assert
            Assert.AreNotSame(id, result);
        }

        [Test]
        public void CategoryId()
        {
            //Arrange
            const int categoryId = 1976;

            //Act
            var suggestion = new Data.Transfer.Objects.SuggestionDto()
            {
                CategoryId = categoryId
            };

            //Assert
            Assert.AreEqual(categoryId, suggestion.CategoryId);
        }

        [Test]
        public void Text_Set_Get()
        {
            //Arrange
            const string label = "Some Name";
            var item = new Data.Transfer.Objects.SuggestionDto
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
            const string category = "Some PropertyType";

            var item = new Data.Transfer.Objects.SuggestionDto { Category = category };

            //Act
            var result = item.Category;

            //Assert
            Assert.AreSame(category, result);
        }
    }
}