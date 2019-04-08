using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Queries.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Geography
{
    public class RegionSuggestionsTranslationQueryTest
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Region%20suggestions%20translation%20query%20test
    {
        [Test]
        public void Instance_Is_SuggestionsTranslationQuery()
        {
            //Arrange
            var type = typeof(SuggestionsTranslationQuery);

            //Act
            var query = Create();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Is_TranslationQuery()
        {
            //Arrange
            var type = typeof(TranslationQuery<IEnumerable<SuggestionDto>>);

            //Act
            var query = Create();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Term()
        {
            //Arrange
            const string term = "Awesome term";
            var query = Create();

            //Act
            query.Term = term;

            //Assert
            Assert.AreEqual(term, query.Term);
        }

        [Test]
        public void TermRequired()
        {
            //Arrange
            var query = Create();

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
            var query = Create();

            //one character less than allowed
            query.Term = RandomString(2);

            //Act
            var result = Validate(query);

            //Assert
            Assert.True(result.First().MemberNames.First()==nameof(query.Term));
        }

        [Test]
        public void TermMaxLength()
        {
            //Arrange
            var query = Create();

            //one character more than allowed
            query.Term = RandomString(251);

            //Act
            var result = Validate(query);

            //Assert
            Assert.True(result.First().MemberNames.First() == nameof(query.Term));
        }

        public static string RandomString(int length)
        {    var random = new Random();
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

        private static RegionSuggestionsTranslationQuery Create()
        {
            var dispatcher = new Mock<IQueryDispatcher>();

            var query = new RegionSuggestionsTranslationQuery(dispatcher.Object);
            return query;
        }
    }
}