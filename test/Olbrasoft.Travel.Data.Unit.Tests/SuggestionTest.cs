using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Data.Unit.Tests
{
    public class SuggestionTest
    {
        [Test]
        public void Id()
        {
            //Arrange
            const int id = 1976;
            var suggestion = Create();

            //Act
            suggestion.Id = id;

            //Assert
            Assert.AreEqual(id, suggestion.Id);

        }

        private static Suggestion Create()
        {
            var suggestion = new Suggestion();
            return suggestion;
        }
        
        [Test]
        public void Name()
        {
            //Arrange
            const string name = "Awesome name";
            var suggestion = Create();

            //Act
            suggestion.Label = name;

            //Assert
            Assert.AreEqual(name, suggestion.Label);
        }

        
    }
}
