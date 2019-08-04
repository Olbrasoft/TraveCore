using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Business.Services;
using Olbrasoft.Travel.Data.Queries.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;

namespace Olbrasoft.Travel.Business.Unit.Services
{
    [TestFixture]
    internal class RegionServiceTest
    {
        [Test]
        public void Instance_Is_Facade()
        {
            //Arrange
            var type = typeof(Olbrasoft.Querying.Business.ServiceWithQueryFactory);

            //Act
            var service = Service();

            //Assert
            Assert.IsInstanceOf(type, service);
        }

        [Test]
        public void Instance_Implement_Interface_IRegions()
        {
            //Arrange
            var type = typeof(IRegions);

            //Act
            var service = Service();

            //Assert
            Assert.IsInstanceOf(type, service);
        }

        [Test]
        public void GetCountriesAsync_Returns_Task_Of_IEnumerable_Of_CountryItem()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<CountryItemDto>>);
            var service = Service();

            //Act
            var result = service.GetCountriesAsync(1033);

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void GetCountriesAsync_By_continentId_And_languageId_Returns_Task_Of_IEnumerable_Of_CountryItem()
        {
            //Arrange
            //Arrange
            var type = typeof(Task<IEnumerable<CountryItemDto>>);
            var service = Service();

            //Act
            var result = service.GetCountriesAsync(256, 1033);


            //Assert
            Assert.IsInstanceOf(type, result);

        }


        [Test]
        public void GetContinentsAsync_Returns_Task_Of_IEnumerable_Of_ContinentItem()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<ContinentItem>>);
            var service = Service();

            //Act
            var result = service.GetContinentsAsync(1033);

            //Assert
            Assert.IsInstanceOf(type, result);

        }

        [Test]
        public void SuggestionsAsync_Returns_Task_Of_IEnumerable_Of_Suggestion()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<SuggestionDto>>);
            var service = Service();

            //Act
            var result = service.SuggestionsAsync(new[]{""},1033);
            
            //Assert
            Assert.IsInstanceOf(type, result);

        }

        [Test]
        public void MyTestMethod()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<SuggestionDto>>);
            var service = Service();

            //Act
            var result = service.SuggestionsAsync( "" , 1033);

            //Assert
            Assert.IsInstanceOf(type, result);

        }


        private static RegionService Service()
        {
            var providerMock = new Mock<IQueryDispatcher>();
            
            var queryFactoryMock = new Mock<IQueryFactory>();

            queryFactoryMock.Setup(p => p.CreateQuery<ContinentsByLanguageIdQuery>())
                .Returns(new ContinentsByLanguageIdQuery(providerMock.Object));

            queryFactoryMock.Setup(p => p.CreateQuery<CountriesByLanguageIdQuery>())
                .Returns(new CountriesByLanguageIdQuery(providerMock.Object));

            queryFactoryMock.Setup(p => p.CreateQuery<CountriesByContinentIdAndLanguageIdQuery>())
                .Returns(new CountriesByContinentIdAndLanguageIdQuery(providerMock.Object));

            queryFactoryMock.Setup(p => p.CreateQuery<RegionsSuggestionsByTermsTranslationQuery>())
                .Returns(new RegionsSuggestionsByTermsTranslationQuery(providerMock.Object));

            queryFactoryMock.Setup(p => p.CreateQuery<RegionSuggestionsTranslationQuery>())
                .Returns(new RegionSuggestionsTranslationQuery(providerMock.Object));


            return new RegionService(queryFactoryMock.Object);
        }
    }
}