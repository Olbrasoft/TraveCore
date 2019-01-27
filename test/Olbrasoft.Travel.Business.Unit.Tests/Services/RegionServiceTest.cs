using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Queries;
using Olbrasoft.Travel.Business.Services;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Business.Unit.Tests.Services
{
    [TestFixture]
    internal class RegionServiceTest
    {
        [Test]
        public void Instance_Is_Facade()
        {
            //Arrange
            var type = typeof(Olbrasoft.Business.Service);

            //Act
            var facade = Facade();

            //Assert
            Assert.IsInstanceOf(type, facade);
        }

        [Test]
        public void Instance_Implement_Interface_IRegions()
        {
            //Arrange
            var type = typeof(IRegions);

            //Act
            var facade = Facade();

            //Assert
            Assert.IsInstanceOf(type, facade);
        }

        [Test]
        public void GetCountriesAsync_Returns_Task_Of_IEnumerable_Of_CountryItem()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<CountryItem>>);
            var facade = Facade();

            //Act
            var result = facade.GetCountriesAsync(1033);

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void GetCountriesAsync_By_continentId_And_languageId_Returns_Task_Of_IEnumerable_Of_CountryItem()
        {
            //Arrange
            //Arrange
            var type = typeof(Task<IEnumerable<CountryItem>>);
            var facade = Facade();

            //Act
            var result = facade.GetCountriesAsync(256, 1033);


            //Assert
            Assert.IsInstanceOf(type, result);

        }


        [Test]
        public void GetContinentsAsync_Returns_Task_Of_IEnumerable_Of_ContinentItem()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<ContinentItem>>);
            var facade = Facade();

            //Act
            var result = facade.GetContinentsAsync(1033);

            //Assert
            Assert.IsInstanceOf(type, result);

        }
        

        private static RegionService Facade()
        {
            var providerMock = new Mock<IProvider>();

            providerMock.Setup(p => p.Create<ContinentsByLanguageIdQuery>())
                .Returns(new ContinentsByLanguageIdQuery(providerMock.Object));

            providerMock.Setup(p => p.Create<CountriesByLanguageIdQuery>())
                .Returns(new CountriesByLanguageIdQuery(providerMock.Object));

            providerMock.Setup(p => p.Create<CountriesByContinentIdAndLanguageIdQuery>())
                .Returns(new CountriesByContinentIdAndLanguageIdQuery(providerMock.Object));


            return new RegionService(providerMock.Object);
        }
    }
}