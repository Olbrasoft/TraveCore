using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Repositories;
using Olbrasoft.Travel.Providers.Expedia.DataTransfer.Objects.Geography;
using Olbrasoft.Travel.Providers.Expedia.Import.Importers;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Unit.Tests.Importers
{
    public class RegionsToPropertiesImporterTest
    {
        [Test]
        public void MyTestMethod()
        {
            //Arrange
            var type = typeof(Importer<RegionEANHotelIDMapping>);

            //Act
            var importer = Create();

            //Assert
            Assert.IsInstanceOf(type, importer);
        }

        private static PropertiesToRegionsImporter Create()
        {
            var providerMock = new Mock<IProvider>();
            var parserFactoryMock = new Mock<IParserFactory>();
            var repositoriesFactoryMock = new Mock<IRepositoryFactory>();
            var sharedProperties = new SharedProperties(1,1033);
            var loggerMock = new Mock<ILoggingImports>();

            var importer = new PropertiesToRegionsImporter(providerMock.Object, parserFactoryMock.Object, repositoriesFactoryMock.Object, sharedProperties, loggerMock.Object);
            return importer;
        }
    }
}