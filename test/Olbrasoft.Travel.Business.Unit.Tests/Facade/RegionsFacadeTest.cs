using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Business.Facade;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Business.Unit.Tests.Facade
{
    [TestFixture]
    internal class RegionsFacadeTest
    {
        [Test]
        public void Instance_Is_Facade()
        {
            //Arrange
            var type = typeof(Olbrasoft.Business.Facade);

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
            Assert.IsInstanceOf(type,result);
        }


        private static RegionsFacade Facade()
        {
            var providerMock = new Mock<IProvider>();

            providerMock.Setup(p => p.Create<CountriesByLanguageIdQuery>())
                .Returns(new CountriesByLanguageIdQuery(providerMock.Object));
            
            return new RegionsFacade(providerMock.Object);
        }
    }
}