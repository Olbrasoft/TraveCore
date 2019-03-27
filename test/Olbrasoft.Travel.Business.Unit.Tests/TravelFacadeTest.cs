using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Business.Unit.Tests
{
    [TestFixture]
    public class TravelFacadeTest
    {
        [Test]
        public void Instance_Implement_Interface_ITravel()
        {
            //Arrange
            var type = typeof(ITravel);

            //Act
            var facade = Facade();

            //Assert
            Assert.IsInstanceOf(type, facade);
        }

        private static TravelFacade Facade()
        {
            var suggestions = new[]
            {
                new SuggestionDto()
            };

            var task = Task.FromResult(suggestions.AsEnumerable());
            var regionsServiceMock = new Mock<IRegions>();

            regionsServiceMock.Setup(p => p.SuggestionsAsync(It.IsAny<string[]>(),1033, It.IsAny<CancellationToken>()))
                .Returns(task);

            var accommodationsServiceMock = new Mock<IAccommodations>();
            accommodationsServiceMock
                .Setup(p => p.SuggestionsAsync(It.IsAny<string[]>(), 1033, It.IsAny<CancellationToken>()))
                .Returns(task);

            var facade = new TravelFacade(regionsServiceMock.Object,accommodationsServiceMock.Object);
            return facade;
        }

        [Test]
        public void SuggestionsAsync_Return_Task_Of_IEnumerable_Of_Suggestion()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<SuggestionDto>>);
            const string term = "Some term";
            const int languageId = 1033;

            var facade = Facade();

            //Act
            var result = facade.SuggestionsAsync(term, languageId);

            //Assert
            Assert.IsInstanceOf(type, result);
        }
    }
}