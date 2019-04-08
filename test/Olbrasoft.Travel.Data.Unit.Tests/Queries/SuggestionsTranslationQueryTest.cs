using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    public class SuggestionsTranslationQueryTest
    {
        [Test]
        public void SuggestionByTermTranslationQuery_Is_Abstract()
        {
            //Arrange
            var type = typeof(SuggestionsTranslationQuery);

            //Act
            var result = type.IsAbstract;

            //Assert
            Assert.True(result);
        }

        [Test]
        public void Instance_Is_SuggestionsTranslationQuery()
        {
            //Arrange
            var type = typeof(SuggestionsTranslationQuery);

            //Act
            var query = CreateQuery();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Is_TranslationQuery()
        {
            //Arrange
            var type = typeof(TranslationQuery<IEnumerable<SuggestionDto>>);

            //Act
            var query = CreateQuery();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Term()
        {
            //Arrange
            const string term = "Awesome term";
            var query = CreateQuery();

            //Act
            query.Term = term;

            //Assert
            Assert.AreEqual(term, query.Term);
        }

        [Test]
        public void TermRequired()
        {
            //Arrange
            var query = CreateQuery();

            //one character less than allowed
            query.Term = RandomString(0);

            //Act
            var result = Validate(query);

            //Assert
            Assert.True(result.First().MemberNames.First() == nameof(query.Term));
        }

        [Test]
        public void TermMinLength()
        {
            //Arrange
            var query = CreateQuery();

            //one character less than allowed
            query.Term = RandomString(2);

            //Act
            var result = Validate(query);

            //Assert
            Assert.True(result.First().MemberNames.First() == nameof(query.Term));
        }

        [Test]
        public void TermMaxLength()
        {
            //Arrange
            var query = CreateQuery();

            //one character more than allowed
            query.Term = RandomString(251);

            //Act
            var result = Validate(query);

            //Assert
            Assert.True(result.First().MemberNames.First() == nameof(query.Term));
        }

        private static AwesomeSuggestionsByTermTranslationQuery CreateQuery()
        {
            var dispatcher = new Mock<IQueryDispatcher>();

            var query = new AwesomeSuggestionsByTermTranslationQuery(dispatcher.Object);
            return query;
        }

        public static string RandomString(int length)
        {
            var random = new Random();
            // ASCII printable characters
            var chars = Enumerable.Range(33, 94).ToArray().Select(a => (char)a).ToArray();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static IList<ValidationResult> Validate(object model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, context, results, true);
            if (model is IValidatableObject validatableObject) validatableObject.Validate(context);
            return results;
        }
    }
}