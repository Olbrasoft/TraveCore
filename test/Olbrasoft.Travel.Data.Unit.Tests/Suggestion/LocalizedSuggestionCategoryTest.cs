using NUnit.Framework;
using Olbrasoft.Data;
using Olbrasoft.Travel.Data.Localization;
using Olbrasoft.Travel.Data.Suggestion;

namespace Olbrasoft.Travel.Data.Unit.Tests.Suggestion
{
    [TestFixture]
    internal class LocalizedSuggestionCategoryTest
    {
        [Test]
        public void Instance_Is_Localized()
        {
            //Arrange
            var type = typeof(Localized);

            //Act
            var localizedSuggestionType = Create();

            //Assert
            Assert.IsInstanceOf(type, localizedSuggestionType);
        }

        private static LocalizedSuggestionCategory Create()
        {
            var localizedSuggestionType = new LocalizedSuggestionCategory();
            return localizedSuggestionType;
        }

        [Test]
        public void Instance_Implement_Interface_IHaveLabel()
        {
            //Arrange
            var type = typeof(IHaveLabel);

            //Act
            var localizedSuggestionType = Create();

            //Assert
            Assert.IsInstanceOf(type, localizedSuggestionType);
        }

        [Test]
        public void Label()
        {
            //Arrange
            const string label = "Awesome label";
            var localizedSuggestionType = Create();

            //Act
            localizedSuggestionType.Name = label;

            //Assert
            Assert.AreEqual(label, localizedSuggestionType.Name);
        }

        [Test]
        public void Instance_Implement_Interface_IHaveType_Of_SuggestionType()
        {
            //Arrange
            var type = typeof(IHaveType<SuggestionCategory>);

            //Act
            var localizedSuggestionType = Create();

            //Assert
            Assert.IsInstanceOf(type, localizedSuggestionType);
        }

        [Test]
        public void Type()
        {
            //Arrange
            var type = new SuggestionCategory();
            var localizedSuggestionType = Create();

            //Act
            localizedSuggestionType.Category = type;

            //Assert
            Assert.AreSame(type, localizedSuggestionType.Category);
        }
    }
}